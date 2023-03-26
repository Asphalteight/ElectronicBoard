using System.Net;
using Board.Application.AppData.Context.Subcategory.Services;
using Board.Contracts.Contexts;
using Board.Contracts.Contexts.Subcategories;
using Microsoft.AspNetCore.Mvc;

namespace Board.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с подкатегориями.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[Controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class SubcategoryController : ControllerBase
{
    private readonly ILogger<SubcategoryController> _logger;
    private readonly ISubcategoryService _subcategoryService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="SubcategoryController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="subcategoryService">Сервис подкатегорий.</param>
    public SubcategoryController(ILogger<SubcategoryController> logger, ISubcategoryService subcategoryService)
    {
        _logger = logger;
        _subcategoryService = subcategoryService;
    }

    /// <summary>
    /// Получить список подкатегорий.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <returns>Список моделей подкатегорий.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InfoSubcategoryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрос подкатегорий");
        var result = await _subcategoryService.GetAllSubcategories(cancellationToken);
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Получить подкатегорию по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Объявления с указанным идентификатором не найдена.</response>
    /// <returns>Модель подкатегории.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InfoSubcategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _subcategoryService.GetSubcategoryByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Создать новую подкатегорию.
    /// </summary>
    /// <param name="dto">Модель создания подкатегории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Объявления успешно создана.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Идентификатор созданной подкатегории.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromQuery] CreateSubcategoryDto dto, CancellationToken cancellationToken)
    {
        var result = await _subcategoryService.CreateSubcategoryAsync(dto, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, result);
    }

    /// <summary>
    /// Обновить подкатегорию.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления подкатегории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Объявления с указанным идентификатором не найдена.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Модель обновленной подкатегории.</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(InfoSubcategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(int id, [FromQuery] UpdateSubcategoryDto dto, CancellationToken cancellationToken)
    {
        var result = await _subcategoryService.UpdateSubcategoryAsync(id, dto, cancellationToken);
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Удалить подкатегорию по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="204">Запрос выполнен успешно.</response>
    /// <response code="403">Доступ запрещён.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteById(int id, CancellationToken cancellationToken)
    {
        var result = await _subcategoryService.DeleteSubcategoryAsync(id, cancellationToken);
        return await Task.Run( () => Ok(result), cancellationToken);
    }
}