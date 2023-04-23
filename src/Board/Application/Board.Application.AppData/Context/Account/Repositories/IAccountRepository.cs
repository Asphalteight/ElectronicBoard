using System.Linq.Expressions;
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
    /// <returns>Информация об измененном аккаунте.</returns>
    Task<InfoAccountDto> UpdateAsync(Accounts model, CancellationToken cancellationToken);

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
    /// <returns>Модель аккаунта.</returns>
    Task<Accounts?> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Поиск пользователя по фильтру.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<Accounts> FindWhere(Expression<Func<Accounts, bool>> predicate, CancellationToken cancellation);
    
    /// <summary>
    /// Получение всех аккаунтов.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех аккаунтов.</returns>
    Task<IEnumerable<InfoAccountDto>> GetAllAsync(CancellationToken cancellationToken);
}