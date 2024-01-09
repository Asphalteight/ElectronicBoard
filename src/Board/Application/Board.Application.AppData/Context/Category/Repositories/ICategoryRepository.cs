using Board.Contracts.Contexts.Categories;
using Board.Domain.Category;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Board.Application.AppData.Context.Category.Repositories;

/// <summary>
/// Репозиторий для работы с категориями.
/// </summary>
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
    /// <returns>Информация об измененной категории.</returns>
    Task<InfoCategoryDto> UpdateAsync(Categories model, CancellationToken cancellationToken);

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
    /// <returns>Модель категории.</returns>
    Task<Categories> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение подкатегорий по идентификатору родителя.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список подкатегорий.</returns>
    Task<IEnumerable<InfoCategoryDto>> GetChildByIdAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение всех категорий.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех аккаунтов.</returns>
    Task<IEnumerable<InfoCategoryDto>> GetAllAsync(CancellationToken cancellationToken);
}