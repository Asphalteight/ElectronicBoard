using Board.Contracts.Contexts.Messages;

namespace Board.Application.AppData.Context.Message.Services;

/// <summary>
/// Сервис для работы с сообщениями.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Создание сообщения.
    /// </summary>
    /// <param name="model">Модель сообщения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного сообщения.</returns>
    Task<int> CreateMessageAsync(CreateMessageDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение сообщения.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об измененном сообщении.</returns>
    Task<InfoMessageDto?> UpdateMessageAsync(int id, UpdateMessageDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление сообщения.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого сообщения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteMessageAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сообщения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация об сообщении.</returns>
    Task<InfoMessageDto?> GetMessageByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех сообщений.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список сообщений.</returns>
    Task<IEnumerable<InfoMessageDto>> GetAllMessages(CancellationToken cancellationToken);
}