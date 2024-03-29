﻿using Board.Application.AppData.Context.Message.Services;
using Board.Contracts.Contexts;
using Board.Contracts.Contexts.Messages;
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
/// Контроллер для работы с сообщениями.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[Controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class MessageController : ControllerBase
{
    private readonly ILogger<MessageController> _logger;
    private readonly IMessageService _messageService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="MessageController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="messageService">Сервис сообщений.</param>
    public MessageController(ILogger<MessageController> logger, IMessageService messageService)
    {
        _logger = logger;
        _messageService = messageService;
    }

    /// <summary>
    /// Получить список сообщений.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <returns>Список моделей сообщений.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InfoMessageDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрошены все сообщения");
        var result = await _messageService.GetAllMessages(cancellationToken);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Получить сообщение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Сообщение с указанным идентификатором не найдено.</response>
    /// <returns>Модель сообщения.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InfoMessageDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _messageService.GetMessageByIdAsync(id, cancellationToken);
        _logger.LogInformation("Запрошено сообщение с идентификатором: {0}", id);

        if (result == null)
        {
            _logger.LogError("Сообщение с запрашиваемым идентификатором \"{0}\" не найдено", id);
            return NotFound();
        }
        
        return Ok(result);
    }

    /// <summary>
    /// Создать новое сообщение.
    /// </summary>
    /// <param name="dto">Модель создания сообщения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Сообщение успешно создано.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Идентификатор созданного сообщения.</returns>
    [HttpPost("create")]
    [Authorize]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateMessageDto dto, CancellationToken cancellationToken)
    {
        var result = await _messageService.CreateMessageAsync(dto, cancellationToken);
        _logger.LogInformation("Создано новое сообщение с идентификатором: {0}", result);
        
        return StatusCode((int)HttpStatusCode.Created, result);
    }

    /// <summary>
    /// Обновить сообщение.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления сообщения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Сообщение с указанным идентификатором не найдено.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Модель обновленного сообщения.</returns>
    [HttpPut("{id:int}")]
    [Authorize]
    [ProducesResponseType(typeof(InfoMessageDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(int id, [FromQuery] UpdateMessageDto dto, CancellationToken cancellationToken)
    {
        var result = await _messageService.UpdateMessageAsync(id, dto, cancellationToken);
        if (result == null)
        {
            _logger.LogError("Ошибка при обновлении сообщения");
            return BadRequest();
        }
        _logger.LogInformation("Обновлено сообщение с идентификатором: {0}", id);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Удалить сообщение по идентификатору.
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
        var result = await _messageService.DeleteMessageAsync(id, cancellationToken);
        _logger.LogInformation("Удалено сообщение с идентификатором: {0}, с результатом {1}", id, result);
        
        return await Task.Run( () => Ok(result), cancellationToken);
    }
}