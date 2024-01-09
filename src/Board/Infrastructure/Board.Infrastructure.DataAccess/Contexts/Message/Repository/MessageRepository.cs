using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Context.Message.Repositories;
using Board.Contracts.Contexts.Messages;
using Board.Domain.Message;
using Board.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Board.Infrastructure.DataAccess.Contexts.Message.Repository;

/// <inheritdoc/> 
public class MessageRepository : IMessageRepository
{
    private readonly IRepository<Messages> _repository;
    private readonly IMapper _mapper;
    
    public MessageRepository(IRepository<Messages> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/> 
    public async Task<int> CreateAsync(Messages model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model, cancellationToken);
        
        return model.Id;
    }
    
    /// <inheritdoc/> 
    public async Task<InfoMessageDto> UpdateAsync(Messages model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model, cancellationToken);
        
        return _mapper.Map<Messages, InfoMessageDto>(model);
    }
    
    /// <inheritdoc/> 
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var model = _repository.GetAllFiltered(s => s.Id == id).FirstOrDefault();
        if (model == null)
        {
            return false;
        }
        
        await _repository.DeleteAsync(model, cancellationToken);
        
        return true;
    }
    
    /// <inheritdoc/> 
    public async Task<Messages> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = _repository.GetAll().Where(s => s.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
        
        return await result;
    }
    
    /// <inheritdoc/>
    public async Task<IEnumerable<InfoMessageDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAll().ProjectTo<InfoMessageDto>(_mapper.ConfigurationProvider).OrderBy(o => o.Id).ToListAsync(cancellationToken: cancellationToken);
    }
}