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
    Task<int> CreateAccountAsync(CreateAccountDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение аккаунта.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном аккаунте.</returns>
    Task<InfoAccountDto> ReplaceAccountAsync(int id, ReplaceAccountDto dto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Частичное изменение аккаунта.
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
    /// <param name="cancellationToken"></param>
    /// <returns>Список аккаунтов.</returns>
    Task<IEnumerable<InfoAccountDto>> GetAllAccounts(CancellationToken cancellationToken);
}