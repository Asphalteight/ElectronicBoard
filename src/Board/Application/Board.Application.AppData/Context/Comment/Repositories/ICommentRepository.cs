using Board.Contracts.Contexts.Comments;
using Board.Domain.Comment;

namespace Board.Application.AppData.Context.Comment.Repositories;

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
    /// <returns>Статус изменения.</returns>
    Task<bool> UpdateAsync(Comments model, CancellationToken cancellationToken);

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
    Task<InfoCommentDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
}