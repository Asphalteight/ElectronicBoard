using Board.Contracts.Contexts.Comments;

namespace Board.Application.AppData.Context.Comment.Services;

/// <summary>
/// Сервис для работы с комментариями.
/// </summary>
public interface ICommentService
{
    /// <summary>
    /// Создание комментария.
    /// </summary>
    /// <param name="model">Модель комментария.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного комментария.</returns>
    Task<int> CreateCommentAsync(CreateCommentDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение комментария.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном комментарии.</returns>
    Task<InfoCommentDto> UpdateCommentAsync(int id, UpdateCommentDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление комментария.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого комментария.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteCommentAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор комментария.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о комментарии.</returns>
    Task<InfoCommentDto?> GetCommentByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех комментариев.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список комментариев.</returns>
    Task<IEnumerable<InfoCommentDto>> GetAllComments(CancellationToken cancellationToken);
}