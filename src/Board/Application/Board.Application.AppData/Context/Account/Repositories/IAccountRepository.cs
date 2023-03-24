using Board.Domain.Account;
using Board.Contracts.Contexts.Accounts;

namespace Board.Application.AppData.Context.Account.Repositories;

/// <summary>
/// Репозиторий для работы с аккаунтами.
/// </summary>
public interface IAccountRepository
{
    /// <summary>
    /// Создание аккаунта.
    /// </summary>
    /// <param name="model">Модель аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного акканта.</returns>
    Task<int> CreateAsync(Accounts model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение аккаунта.
    /// </summary>
    /// <param name="model">Модель аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус изменения.</returns>
    Task<bool> UpdateAsync(Accounts model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление аккаунта.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор аккаунта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об аккаунте.</returns>
    Task<InfoAccountDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
}