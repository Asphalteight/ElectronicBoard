using Board.Contracts.Contexts.Subcategories;

namespace Board.Application.AppData.Context.Subcategory.Services;

/// <summary>
/// Сервис для работы с подкатегориями.
/// </summary>
public interface ISubcategoryService
{
    /// <summary>
    /// Создание подкатегории.
    /// </summary>
    /// <param name="model">Модель подкатегории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданной подкатегории.</returns>
    Task<int> CreateSubcategoryAsync(CreateSubcategoryDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение подкатегории.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененной подкатегории.</returns>
    Task<InfoSubcategoryDto> UpdateSubcategoryAsync(int id, UpdateSubcategoryDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление подкатегории.
    /// </summary>
    /// <param name="id">Идентификатор удаляемой подкатегории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteSubcategoryAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор подкатегории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о подкатегории.</returns>
    Task<InfoSubcategoryDto?> GetSubcategoryByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех категорий.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список категорий.</returns>
    Task<IEnumerable<InfoSubcategoryDto>> GetAllSubcategories(CancellationToken cancellationToken);
}