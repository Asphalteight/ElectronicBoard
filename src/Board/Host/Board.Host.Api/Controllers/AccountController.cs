using Board.Application.AppData.Context.Account.Services;
using Board.Contracts.Contexts;
using Board.Contracts.Contexts.Accounts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Board.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с аккаунтами.
/// </summary>
/// <response code="500">Произошла внутренняя ошибка.</response>
[ApiController]
[Route("[Controller]")]
[Produces("application/json")]
[AllowAnonymous]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAccountService _accountService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="AccountController"/>
    /// </summary>
    /// <param name="logger">Сервис логирования.</param>
    /// <param name="accountService">Сервис аккаунтов.</param>
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
        _logger.LogInformation("Запрошены все аккаунты");
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
        _logger.LogInformation("Запрошен аккаунт с идентификатором: {0}", id);

        if (result == null)
        {
            _logger.LogError("Аккаунт с запрашиваемым идентификатором \"{0}\" не найден", id);
            return NotFound();
        }
        
        return Ok(result);
    }


    /// <summary>
    /// Зарегистрировать новый аккаунт.
    /// </summary>
    /// <param name="dto">Модель регистрации аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <response code="201">Аккаунт успешно зарегистрирован.</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="422">Произошёл конфликт бизнес-логики.</response>
    /// <returns>Идентификатор зарегистрированного аккаунта.</returns>
    [HttpPost("registration")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> RegisterAccount([FromBody] CreateAccountDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.RegisterAccountAsync(dto, cancellationToken);
        if (result == 0)
        {
            _logger.LogError("Ошибка при создании аккаунта, Email: {0}", dto.Email);
            return BadRequest();
        }
        _logger.LogInformation("Зарегистрирован новый аккаунт с идентификатором: {0}", result);
        
        return await Task.Run(() => CreatedAtAction(nameof(Login), result), cancellationToken);
    }
    
    /// <summary>
    /// Войти в аккаунт.
    /// </summary>
    /// <param name="dto">Модель входа в аккаунт.</param>
    /// <param name="cancellation">Токен отмены.</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="400">Модель данных запроса невалидна.</response>
    /// <response code="403">Доступ запрещён (пользователь заблокирован).</response>
    /// <response code="404">Пользователь не найден.</response>
    /// <returns>Модель с данными входа.</returns>
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromQuery] LoginAccountDto dto, CancellationToken cancellation)
    {
        var result = await _accountService.LoginAsync(dto, cancellation);
        _logger.LogInformation("Совершен вход аккаунт, Email: {0}", dto.Email);
        
        return await Task.Run(() => Ok(result), cancellation);
    }

    /// <summary>
    /// Выйти из аккаунта.
    /// </summary>
    /// <param name="token"></param>
    [HttpPost("logout")]
    public async Task Logout(string token)
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
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
    public async Task<IActionResult> Update(int id, [FromQuery] UpdateAccountDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.UpdateAccountAsync(id, dto, cancellationToken);
        if (result == null)
        {
            _logger.LogError("Ошибка при обновлении аккаунта, Id: {0}", id);
            return BadRequest();
        }
        _logger.LogInformation("Обновлен аккаунт с идентификатором: {0}", id);
        
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
        _logger.LogInformation("Удален аккаунт с идентификатором: {0}, с результатом {1}", id, result);
        
        return await Task.Run( () => Ok(result), cancellationToken);
    }
}