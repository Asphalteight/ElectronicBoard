using Board.Contracts.Contexts.Comments;
using Board.Domain.Comment;

namespace Board.Application.AppData.Context.Comment.Repositories;

/// <summary>
/// Репозиторий для работы с комментариями.
/// </summary>
public interface ICommentRepository
{
    /// <summary>
    /// Создание комментария.
    /// </summary>
    /// <param name="model">Модель комментария.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного комментария.</returns>
    Task<int> CreateAsync(Comments model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение комментария.
    /// </summary>
    /// <param name="model">Модель комментария.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном комментарии.</returns>
    Task<InfoCommentDto> UpdateAsync(Comments model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление комментария.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого комментария.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор комментария.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о комментарии.</returns>
    Task<Comments?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение всех комментариев.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех комментариев.</returns>
    Task<IEnumerable<InfoCommentDto>> GetAllAsync(CancellationToken cancellationToken);
}