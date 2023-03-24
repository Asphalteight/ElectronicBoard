using Board.Contracts.Contexts.Advertisements;
using Board.Domain.Advertisement;

namespace Board.Application.AppData.Context.Advertisement.Repositories;

public interface IAdvertisementRepository
{
    /// <summary>
    /// Создание объявления.
    /// </summary>
    /// <param name="model">Модель объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного объявления.</returns>
    Task<int> CreateAsync(Advertisements model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение объявления.
    /// </summary>
    /// <param name="model">Модель объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус изменения.</returns>
    Task<bool> UpdateAsync(Advertisements model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление объявления.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об объявлении.</returns>
    Task<InfoAdvertisementDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
}