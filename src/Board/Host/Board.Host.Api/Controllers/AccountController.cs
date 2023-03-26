﻿using System.Net;
using Board.Application.AppData.Context.Account.Services;
using Board.Contracts.Contexts;
using Board.Contracts.Contexts.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Board.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с аккаунтами.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[Controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAccountService _accountService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="AccountController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="accountService">Сервис категорий.</param>
    public AccountController(ILogger<AccountController> logger, IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }

    /// <summary>
    /// Получить список аккаунтов.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <returns>Список моделей аккаунтов.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InfoAccountDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрос аккаунтов");
        var result = await _accountService.GetAllAccounts(cancellationToken);
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Получить аккаунт по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="404">Аккаунт с указанным идентификатором не найден.</response>
    /// <returns>Модель аккаунта.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InfoAccountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _accountService.GetAccountByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    // /// <summary>
    // /// Получить список активных категорий.
    // /// </summary>
    // /// <param name="cancellationToken">Токен отмены.</param>
    // /// <response code="200">Запрос выполнен успешно.</response>
    // /// <response code="404">Категория с указанным идентификатором не найдена.</response>
    // /// <returns>Модель категории.</returns>
    // [HttpGet("active")]
    // [ProducesResponseType(typeof(CategoryInfoDto[]), StatusCodes.Status200OK)]
    // public async Task<IActionResult> GetActive(CancellationToken cancellationToken)
    // {
    //     var result = await _categoryService.GetActiveAsync(cancellationToken);
    //     return Ok(result);
    // }

    /// <summary>
    /// Создать новый аккаунт.
    /// </summary>
    /// <param name="dto">Модель создания аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Аккаунт успешно создан.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Идентификатор созданного аккаунта.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromQuery] CreateAccountDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.CreateAccountAsync(dto, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, result);
    }

    /// <summary>
    /// Обновить аккаунт.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Аккаунт с указанным идентификатором не найден.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Модель обновленного аккаунта.</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(InfoAccountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(int id, [FromQuery] ReplaceAccountDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.ReplaceAccountAsync(id, dto, cancellationToken);
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Частично обновить аккаунт.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён.</response>
    /// <response code="404">Аккаунт с указанным идентификатором не найден.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Модель обновленного аккаунта.</returns>
    [HttpPatch("{id:int}")]
    [ProducesResponseType(typeof(InfoAccountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Patch(int id, [FromQuery] UpdateAccountDto dto,
        CancellationToken cancellationToken)
    {
        var result = await _accountService.UpdateAccountAsync(id, dto, cancellationToken);
        return await Task.Run(() => Ok(result), cancellationToken);
    }

    /// <summary>
    /// Удалить аккаунт по идентификатору.
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
        var result = await _accountService.DeleteAccountAsync(id, cancellationToken);
        return await Task.Run( () => Ok(result), cancellationToken);
    }
}