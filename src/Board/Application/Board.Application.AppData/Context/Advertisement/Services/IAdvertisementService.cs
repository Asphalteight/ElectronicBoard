using Board.Contracts.Contexts.Advertisements;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Board.Application.AppData.Context.Advertisement.Services;

/// <summary>
/// Сервис для работы с объявлениями.
/// </summary>
public interface IAdvertisementService
{
    /// <summary>
    /// Создание объявления.
    /// </summary>
    /// <param name="model">Модель объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного объявления.</returns>
    Task<int> CreateAdvertisementAsync(CreateAdvertisementDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение объявления.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном объявлении.</returns>
    Task<InfoAdvertisementDto> UpdateAdvertisementAsync(int id, UpdateAdvertisementDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление объявления.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteAdvertisementAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об объявлении.</returns>
    Task<InfoAdvertisementDto> GetAdvertisementByIdAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение по фильтру.
    /// </summary>
    /// <param name="dto">Модель поиска объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список найденных объявлений.</returns>
    Task<IEnumerable<InfoAdvertisementDto>> FindAdvertisementAsync(SearchAdvertisementDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех объявлений.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список объявлений.</returns>
    Task<IEnumerable<InfoAdvertisementDto>> GetAllAdvertisements(CancellationToken cancellationToken);
}