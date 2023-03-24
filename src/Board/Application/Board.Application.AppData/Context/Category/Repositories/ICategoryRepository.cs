using Board.Contracts.Contexts.Categories;
using Board.Domain.Category;

namespace Board.Application.AppData.Context.Category.Repositories;

public interface ICategoryRepository
{
    /// <summary>
    /// Создание категории.
    /// </summary>
    /// <param name="model">Модель категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданной категории.</returns>
    Task<int> CreateAsync(Categories model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение категории.
    /// </summary>
    /// <param name="model">Модель категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус изменения.</returns>
    Task<bool> UpdateAsync(Categories model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление категории.
    /// </summary>
    /// <param name="id">Идентификатор удаляемой категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о категории.</returns>
    Task<InfoCategoryDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
}