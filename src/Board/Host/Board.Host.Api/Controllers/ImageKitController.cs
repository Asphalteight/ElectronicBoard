using System.Net;
using Board.Application.AppData.Context.ImageKit.Services;
using Board.Contracts.Contexts;
using Board.Contracts.ImageKits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Board.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с наборами изображений.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[Controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class ImageKitController : ControllerBase
{
    private readonly ILogger<ImageKitController> _logger;
    private readonly IImageKitService _imageKitService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="ImageKitController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="imageKitService">Сервис наборов изображений.</param>
    public ImageKitController(ILogger<ImageKitController> logger, IImageKitService imageKitService)
    {
        _logger = logger;
        _imageKitService = imageKitService;
    }

    /// <summary>
    /// Получить список наборов изображений.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <returns>Список моделей объявлений.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InfoImageKitDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрошены все наборы изображений");
        var result = await _imageKitService.GetAllImageKits(cancellationToken);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Получить набор изображений по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Набор изображений с указанным идентификатором не найден.</response>
    /// <returns>Модель набора изображений.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InfoImageKitDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _imageKitService.GetImageKitByIdAsync(id, cancellationToken);
        _logger.LogInformation("Запрошен набор изображений для объявления: {0}", id);

        if (result == null)
        {
            _logger.LogError("Набор изображения с запрашиваемым идентификатором объявления \"{0}\" не найден", id);
            return NotFound();
        }
        
        return Ok(result);
    }

    /// <summary>
    /// Создать новый набор изображений.
    /// </summary>
    /// <param name="dto">Модель создания набора изображений.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Набор изображений успешно создано.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Идентификатор созданного набора изображений.</returns>
    [HttpPost("create")]
    [Authorize]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromQuery] CreateImageKitDto dto, CancellationToken cancellationToken)
    {
        var result = await _imageKitService.CreateImageKitAsync(dto, cancellationToken);
        _logger.LogInformation("Создан новый набор изоображений с идентификатором объявления: {0}", result);
        
        return StatusCode((int)HttpStatusCode.Created, result);
    }

    /// <summary>
    /// Обновить набор изображений.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления набора изображений.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Набора изображений с указанным идентификатором не найден.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Модель обновленного набора изображений.</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(InfoImageKitDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(int id, [FromQuery] UpdateImageKitDto dto, CancellationToken cancellationToken)
    {
        var result = await _imageKitService.UpdateImageKitAsync(id, dto, cancellationToken);
        _logger.LogInformation("Обновлен набор изображений с идентификатором объявления: {0}", result?.AdvertisementId);
        
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Удалить набор изображений по идентификатору.
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
        var result = await _imageKitService.DeleteImageKitAsync(id, cancellationToken);
        _logger.LogInformation("Удален набор изображений с идентификатором объявления: {0}, с результатом {1}", id, result);
        
        return await Task.Run( () => Ok(result), cancellationToken);
    }
}