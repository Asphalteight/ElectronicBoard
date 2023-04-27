using System.Net;
using Board.Application.AppData.Context.Category.Services;
using Board.Contracts.Contexts;
using Board.Contracts.Contexts.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Board.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с категориями.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[Controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="CategoryController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="categoryService">Сервис категорий.</param>
    public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    /// <summary>
    /// Получить список категорий.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <returns>Список моделей категорий.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InfoCategoryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрошены все категории");
        var result = await _categoryService.GetAllCategories(cancellationToken);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Получить категорию по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Категория с указанным идентификатором не найдена.</response>
    /// <returns>Модель категории.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InfoCategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetCategoryByIdAsync(id, cancellationToken);
        _logger.LogInformation("Запрошена категория с идентификатором: {0}", id);

        if (result == null)
        {
            _logger.LogError("Категория с запрашиваемым идентификатором \"{0}\" не найдена", id);
            return NotFound();
        }
        
        return Ok(result);
    }
    
    /// <summary>
    /// Получить все дочерние подкатегории для категории.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Категория с указанным идентификатором не найдена.</response>
    /// <returns>Модель категории.</returns>
    [HttpGet("childFor/{id:int}")]
    [ProducesResponseType(typeof(InfoCategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetChildById(int id, CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetChildByIdAsync(id, cancellationToken);
        _logger.LogInformation("Запрошены все дочерние подкатегории для катеории с идентификатором: {0}", id);

        if (result == null)
        {
            _logger.LogError("Категория с запрашиваемым идентификатором \"{0}\" не найдена", id);
            return NotFound();
        }
        
        return Ok(result);
    }

    /// <summary>
    /// Создать новую категорию.
    /// </summary>
    /// <param name="dto">Модель создания категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Объявления успешно создана.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Идентификатор созданной категории.</returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromQuery] CreateCategoryDto dto, CancellationToken cancellationToken)
    {
        var result = await _categoryService.CreateCategoryAsync(dto, cancellationToken);
        _logger.LogInformation("Создана новая категория с идентификатором: {0}", result);
        
        return StatusCode((int)HttpStatusCode.Created, result);
    }

    /// <summary>
    /// Обновить категорию.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Категория с указанным идентификатором не найдена.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Модель обновленной категории.</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(InfoCategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(int id, [FromQuery] UpdateCategoryDto dto, CancellationToken cancellationToken)
    {
        var result = await _categoryService.UpdateCategoryAsync(id, dto, cancellationToken);
        _logger.LogInformation("Обновлена категория с идентификатором: {0}", id);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Удалить категорию по идентификатору.
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
        var result = await _categoryService.DeleteCategoryAsync(id, cancellationToken);
        _logger.LogInformation("Удалена категория с идентификатором: {0}, с результатом {1}", id, result);
        
        return await Task.Run( () => Ok(result), cancellationToken);
    }
}