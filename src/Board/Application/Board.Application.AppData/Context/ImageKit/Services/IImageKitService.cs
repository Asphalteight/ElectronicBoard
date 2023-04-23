using Board.Contracts.ImageKits;

namespace Board.Application.AppData.Context.ImageKit.Services;

/// <summary>
/// Сервис для работы с наборами изображений.
/// </summary>
public interface IImageKitService
{
    /// <summary>
    /// Создание набора изображений.
    /// </summary>
    /// <param name="model">Модель набора изображений.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного набора изображений.</returns>
    Task<int> CreateImageKitAsync(CreateImageKitDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение набора изображений.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном наборе изображений.</returns>
    Task<InfoImageKitDto?> UpdateImageKitAsync(int id, UpdateImageKitDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление набора изображений.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого набора изображений.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteImageKitAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор набора изображений.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о наборе изображений.</returns>
    Task<InfoImageKitDto?> GetImageKitByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех наборов изображений.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список наборов изображений.</returns>
    Task<IEnumerable<InfoImageKitDto>> GetAllImageKits(CancellationToken cancellationToken);
}