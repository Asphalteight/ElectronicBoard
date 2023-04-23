using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Context.Comment.Repositories;
using Board.Contracts.Contexts.Comments;
using Board.Domain.Comment;
using Board.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Contexts.Comment.Repository;

/// <inheritdoc/> 
public class CommentRepository : ICommentRepository
{
    private readonly IRepository<Comments> _repository;
    private readonly IMapper _mapper;
    
    public CommentRepository(IRepository<Comments> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/> 
    public async Task<int> CreateAsync(Comments model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model, cancellationToken);
        return model.Id;
    }
    
    /// <inheritdoc/> 
    public async Task<InfoCommentDto> UpdateAsync(Comments model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model, cancellationToken);
        return _mapper.Map<Comments, InfoCommentDto>(model);
    }
    
    /// <inheritdoc/> 
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var model = _repository.GetAllFiltered(s => s.Id == id).FirstOrDefault();
        if (model == null) return false;
        await _repository.DeleteAsync(model, cancellationToken);
        return true;
    }
    
    /// <inheritdoc/> 
    public async Task<Comments?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAll().Where(s => s.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
        return result;
    }
    
    /// <inheritdoc/>
    public async Task<IEnumerable<InfoCommentDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAll().ProjectTo<InfoCommentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken: cancellationToken);
    }
}