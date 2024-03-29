﻿using Board.Application.AppData.Context.Advertisement.Services;
using Board.Contracts.Contexts;
using Board.Contracts.Contexts.Advertisements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Board.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с объявлениями.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[Controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class AdvertisementController : ControllerBase
{
    private readonly ILogger<AdvertisementController> _logger;
    private readonly IAdvertisementService _advertisementService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="AdvertisementController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="advertisementService">Сервис объявлений.</param>
    public AdvertisementController(ILogger<AdvertisementController> logger, IAdvertisementService advertisementService)
    {
        _logger = logger;
        _advertisementService = advertisementService;
    }

    /// <summary>
    /// Получить список объявлений.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <returns>Список моделей объявлений.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InfoAdvertisementDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрошены все объявления");
        var result = await _advertisementService.GetAllAdvertisements(cancellationToken);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Получить объявление по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Объявление с указанным идентификатором не найдено.</response>
    /// <returns>Модель объявления.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InfoAdvertisementDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _advertisementService.GetAdvertisementByIdAsync(id, cancellationToken);
        _logger.LogInformation("Запрошено объявление с идентификатором: {0}", id);

        if (result == null)
        {
            _logger.LogError("Объявление с запрашиваемым идентификатором \"{0}\" не найдено", id);
            return NotFound();
        }
        
        return Ok(result);
    }
    
    /// <summary>
    /// Поиск объявления по фильтру.
    /// </summary>
    /// <param name="search">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Объявление с указанным идентификатором не найдено.</response>
    /// <returns>Модель объявления.</returns>
    [HttpGet("search")]
    [ProducesResponseType(typeof(InfoAdvertisementDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromQuery] SearchAdvertisementDto search, CancellationToken cancellationToken)
    {
        var result = await _advertisementService.FindAdvertisementAsync(search, cancellationToken);
        _logger.LogInformation("Поиск объявлений с запросом: {0}", search);

        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Создать новое объявление.
    /// </summary>
    /// <param name="dto">Модель создания объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Объявление успешно создано.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Идентификатор созданного объявления.</returns>
    [HttpPost("create")]
    [Authorize]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateAdvertisementDto dto, CancellationToken cancellationToken)
    {
        var result = await _advertisementService.CreateAdvertisementAsync(dto, cancellationToken);
        _logger.LogInformation("Создано новое объявление с идентификатором: {0}", result);

        if (result == 0)
        {
            _logger.LogError("Ошибка при создании объявления");
            return BadRequest();
        }
        
        return StatusCode((int)HttpStatusCode.Created, result);
    }

    /// <summary>
    /// Обновить объявление.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Объявление с указанным идентификатором не найдено.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Модель обновленного объявления.</returns>
    [HttpPut("{id:int}")]
    [Authorize]
    [ProducesResponseType(typeof(InfoAdvertisementDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(int id, [FromQuery] UpdateAdvertisementDto dto, CancellationToken cancellationToken)
    {
        var result = await _advertisementService.UpdateAdvertisementAsync(id, dto, cancellationToken);
        if (result == null)
        {
            _logger.LogError("Ошибка при обновлении объявления");
            return BadRequest();
        }
        _logger.LogInformation("Обновлено объявление с идентификатором: {0}", id);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Удалить объявление по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="204">Запрос выполнен успешно.</response>
    /// <response code="403">Доступ запрещён.</response>
    [HttpDelete("{id:int}")]
    [Authorize]
    [Authorize(Policy = "AdminPolicy")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteById(int id, CancellationToken cancellationToken)
    {
        var result = await _advertisementService.DeleteAdvertisementAsync(id, cancellationToken);
        _logger.LogInformation("Удалено объявление с идентификатором: {0}, с результатом {1}", id, result);
        
        return await Task.Run( () => Ok(result), cancellationToken);
    }
}