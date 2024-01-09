using Board.Application.AppData.Context.Comment.Services;
using Board.Contracts.Contexts;
using Board.Contracts.Contexts.Comments;
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
/// Контроллер для работы с комментариями.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[Controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class CommentController : ControllerBase
{
    private readonly ILogger<CommentController> _logger;
    private readonly ICommentService _commentService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="CommentController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="commentService">Сервис комментариев.</param>
    public CommentController(ILogger<CommentController> logger, ICommentService commentService)
    {
        _logger = logger;
        _commentService = commentService;
    }

    /// <summary>
    /// Получить список комментариев.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <returns>Список моделей комментариев.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InfoCommentDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрошены все комментарии");
        var result = await _commentService.GetAllComments(cancellationToken);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Получить комментарий по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Комментарий с указанным идентификатором не найден.</response>
    /// <returns>Модель комментария.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InfoCommentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _commentService.GetCommentByIdAsync(id, cancellationToken);
        _logger.LogInformation("Запрошен комментарий с идентификатором: {0}", id);

        if (result == null)
        {
            _logger.LogError("Комментарий с запрашиваемым идентификатором \"{0}\" не найден", id);
            return NotFound();
        }
        
        return Ok(result);
    }

    /// <summary>
    /// Создать новый комментарий.
    /// </summary>
    /// <param name="dto">Модель создания комментария.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Комментарий успешно создан.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Идентификатор созданного комментария.</returns>
    [HttpPost("create")]
    [Authorize]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateCommentDto dto, CancellationToken cancellationToken)
    {
        var result = await _commentService.CreateCommentAsync(dto, cancellationToken);
        _logger.LogInformation("Создан новый комментарий с идентификатором: {0}", result);
        
        return StatusCode((int)HttpStatusCode.Created, result);
    }

    /// <summary>
    /// Обновить комментарий.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления комментария.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Комментарий с указанным идентификатором не найден.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Модель обновленного комментария.</returns>
    [HttpPut("{id:int}")]
    [Authorize]
    [ProducesResponseType(typeof(InfoCommentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(int id, [FromQuery] UpdateCommentDto dto, CancellationToken cancellationToken)
    {
        var result = await _commentService.UpdateCommentAsync(id, dto, cancellationToken);
        if (result == null)
        {
            _logger.LogError("Ошибка при обновлении комментария");
            return BadRequest();
        }
        _logger.LogInformation("Обновлен комментарий с идентификатором: {0}", id);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Удалить комментарий по идентификатору.
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
        var result = await _commentService.DeleteCommentAsync(id, cancellationToken);
        _logger.LogInformation("Удален комментарий с идентификатором: {0}, с результатом {1}", id, result);
        
        return await Task.Run( () => Ok(result), cancellationToken);
    }
}