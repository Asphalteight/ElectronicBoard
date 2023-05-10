using AutoMapper;
using Board.Application.AppData.Context.Message.Repositories;
using Board.Contracts.Contexts.Messages;
using Board.Domain.Message;

namespace Board.Application.AppData.Context.Message.Services;

/// <inheritdoc/>
public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public MessageService(IMessageRepository messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<int> CreateMessageAsync(CreateMessageDto model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CreateMessageDto, Messages>(model);
        
        return await _messageRepository.CreateAsync(entity, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InfoMessageDto?> UpdateMessageAsync(int id, UpdateMessageDto dto, CancellationToken cancellationToken)
    {
        var message = await _messageRepository.GetByIdAsync(id, cancellationToken);
        if (message == null)
        {
            return null;
        }

        var updated = _mapper.Map(dto, message);
        
        return await _messageRepository.UpdateAsync(updated, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteMessageAsync(int id, CancellationToken cancellationToken)
    {
        var result = _messageRepository.DeleteAsync(id, cancellationToken);
        
        return await result;
    }

    /// <inheritdoc/>
    public async Task<InfoMessageDto?> GetMessageByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _messageRepository.GetByIdAsync(id, cancellationToken);
        
        return _mapper.Map<Messages?, InfoMessageDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoMessageDto>> GetAllMessages(CancellationToken cancellationToken)
    {
        var entities = _messageRepository.GetAllAsync(cancellationToken);
        
        return await entities;
    }
}