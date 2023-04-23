using Board.Contracts.ImageKits;
using Board.Domain.ImageKit;

namespace Board.Application.AppData.Context.ImageKit.Repositories;

/// <summary>
/// Репозиторий для работы с наборами изображений.
/// </summary>
public interface IImageKitRepository
{
    /// <summary>
    /// Создание набора изображений.
    /// </summary>
    /// <param name="model">Модель набора изображений.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного набора изображений.</returns>
    Task<int> CreateAsync(ImageKits model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение набора изображений.
    /// </summary>
    /// <param name="model">Модель набора изображений.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном наборе изображений.</returns>
    Task<InfoImageKitDto> UpdateAsync(ImageKits model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление набора изображений.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого набора изображений.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор набора изображений.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о набора изображений.</returns>
    Task<ImageKits?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение всех наборов изображений.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех наборов изображений.</returns>
    Task<IEnumerable<InfoImageKitDto>> GetAllAsync(CancellationToken cancellationToken);
}