using Board.Contracts.Contexts.Messages;
using Board.Domain.Message;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
    /// <returns>Информация об измененном сообщении.</returns>
    Task<InfoMessageDto> UpdateAsync(Messages model, CancellationToken cancellationToken);

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
    Task<Messages> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение всех сообщений.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех объявлений.</returns>
    Task<IEnumerable<InfoMessageDto>> GetAllAsync(CancellationToken cancellationToken);
}