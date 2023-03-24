using Board.Contracts.Contexts.Subcategories;
using Board.Domain.Category;

namespace Board.Application.AppData.Context.Subcategory.Repositories;

public interface ISubcategoryRepository
{
    /// <summary>
    /// Создание подкатегории.
    /// </summary>
    /// <param name="model">Модель подкатегории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданной подкатегории.</returns>
    Task<int> CreateAsync(Subcategories model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение подкатегории.
    /// </summary>
    /// <param name="model">Модель подкатегории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус изменения.</returns>
    Task<bool> UpdateAsync(Subcategories model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление подкатегории.
    /// </summary>
    /// <param name="id">Идентификатор удаляемой подкатегории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор подкатегории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о подкатегории.</returns>
    Task<InfoSubcategoryDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
}