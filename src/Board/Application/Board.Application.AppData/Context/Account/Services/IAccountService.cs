using Board.Contracts.Contexts.Accounts;

namespace Board.Application.AppData.Context.Account.Services;

/// <summary>
/// Сервис для работы с аккаунтами.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Создание аккаунта.
    /// </summary>
    /// <param name="model">Модель аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного аккаунта.</returns>
    Task<int> RegisterAccountAsync(CreateAccountDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Авторизация в аккаунте.
    /// </summary>
    /// <param name="model">Модель для логина.</param>
    /// <param name="cancellation">Токен отмены.</param>
    /// <returns>Токен.</returns>
    Task<string> LoginAsync(LoginAccountDto model, CancellationToken cancellation);

    /// <summary>
    /// Получение текущего пользователя.
    /// </summary>
    /// <param name="cancellation">Токен отмены.</param>
    /// <returns>Текущий пользователь.</returns>
    Task<InfoAccountDto> GetCurrentAsync(CancellationToken cancellation);

    /// <summary>
    /// Изменение аккаунта.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном аккаунте.</returns>
    Task<InfoAccountDto> UpdateAccountAsync(int id, UpdateAccountDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление аккаунта.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteAccountAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об аккаунте.</returns>
    Task<InfoAccountDto?> GetAccountByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех аккаунтов.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список аккаунтов.</returns>
    Task<IEnumerable<InfoAccountDto>> GetAllAccounts(CancellationToken cancellationToken);
}