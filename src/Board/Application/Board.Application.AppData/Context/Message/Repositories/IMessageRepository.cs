using Board.Contracts.Contexts.Messages;
using Board.Domain.Message;

namespace Board.Application.AppData.Context.Message.Repositories;

public interface IMessageRepository
{
    /// <summary>
    /// Создание сообщения.
    /// </summary>
    /// <param name="model">Модель сообщения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного сообщения.</returns>
    Task<int> CreateAsync(Messages model, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение сообщения.
    /// </summary>
    /// <param name="model">Модель сообщения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус изменения.</returns>
    Task<bool> UpdateAsync(Messages model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление сообщения.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого сообщения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус удаления.</returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сообщения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о сообщении.</returns>
    Task<InfoMessageDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
}