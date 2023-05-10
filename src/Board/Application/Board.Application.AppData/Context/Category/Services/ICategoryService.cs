using Board.Contracts.Contexts.Categories;

namespace Board.Application.AppData.Context.Category.Services;

/// <summary>
/// Сервис для работы с категориями.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Создание категории.
    /// </summary>
    /// <param name="model">Модель категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданной категории.</returns>
    Task<int> CreateCategoryAsync(CreateCategoryDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение категории.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененной категории.</returns>
    Task<InfoCategoryDto?> UpdateCategoryAsync(int id, UpdateCategoryDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление категории.
    /// </summary>
    /// <param name="id">Идентификатор удаляемой категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteCategoryAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о категории.</returns>
    Task<InfoCategoryDto?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение подкатегорий по идентификатору родителя.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список подкатегорий.</returns>
    Task<IEnumerable<InfoCategoryDto>?> GetChildByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех категорий.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список категорий.</returns>
    Task<IEnumerable<InfoCategoryDto>> GetAllCategories(CancellationToken cancellationToken);
}