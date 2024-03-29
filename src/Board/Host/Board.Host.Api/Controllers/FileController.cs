﻿using Board.Application.AppData.Context.File.Services;
using Board.Contracts.Contexts;
using Board.Contracts.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Board.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с файлами.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class FileController : ControllerBase
{
    private readonly ILogger<FileController> _logger;
    private readonly IFileService _fileService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="FileController"/>
    /// </summary>
    /// <param name="fileService">Сервис работы с файлами.</param>
    /// <param name="logger">Сервис логирования.</param>
    public FileController(IFileService fileService, ILogger<FileController> logger)
    {
        _logger = logger;
        _fileService = fileService;
    }

    /// <summary>
    /// Получение информации о файле по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Файл с указанным идентификатором не найден.</response>
    /// <returns>Информация о файле.</returns>
    [HttpGet("{id}/info")]
    [ProducesResponseType(typeof(FileInfoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInfoById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _fileService.GetInfoByIdAsync(id, cancellationToken);
        _logger.LogInformation("Запрошен файл с идентификатором: {0}", id);

        if (result == null)
        {
            _logger.LogError("Файл с запрашиваемым идентификатором \"{0}\" не найден", id);
            return NotFound();
        }
        
        return Ok(result);
    }

    /// <summary>
    /// Загрузка файла в систему.
    /// </summary>
    /// <param name="files">Файл.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Файл успешно загружен.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    [HttpPost("create")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = long.MaxValue)]
    [DisableRequestSizeLimit]
    public async Task<IActionResult> Upload(IFormFileCollection files, CancellationToken cancellationToken)
    {
        List<Guid> result = new List<Guid>();
        foreach (var file in files)
        {
            var bytes = await GetBytesAsync(file, cancellationToken);
            var fileDto = new FileDto
            {
                Content = bytes,
                ContentType = file.ContentType,
                Name = file.FileName
            };
            result.Add(await _fileService.UploadAsync(fileDto, cancellationToken));
            
            _logger.LogInformation("Добавлен новый файл с идентификатором: {0}", result);
        }
        
        return StatusCode((int)HttpStatusCode.Created, result);
    }

    /// <summary>
    /// Скачивание файла по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Файл с указанным идентификатором не найден.</response>
    /// <returns>Файл в виде потока.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Download(Guid id, CancellationToken cancellationToken)
    {
        var result = await _fileService.DownloadAsync(id, cancellationToken);
        _logger.LogInformation("Скачивание файла с идентификатором: {0}", id);
        
        if (result == null) 
        {
            _logger.LogError("Файл для скачивания с запрашиваемым идентификатором \"{0}\" не найден", id);
            return NotFound();
        }

        Response.ContentLength = result.Content.Length;
        
        return File(result.Content, result.ContentType, result.Name, true);
    }


    /// <summary>
    /// Удаление файла по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Файл с указанным идентификатором не найден.</response>
    [HttpDelete("{id}")]
    [Authorize]
    [Authorize(Policy = "AdminPolicy")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _fileService.DeleteAsync(id, cancellationToken);
        _logger.LogInformation("Удаление файла с идентификатором: {0}", id);
        
        return NoContent();
    }

    private static async Task<byte[]> GetBytesAsync(IFormFile file, CancellationToken cancellationToken)
    {
        using var ms = new MemoryStream();
        await file.CopyToAsync(ms, cancellationToken);
        return ms.ToArray();
    }
}