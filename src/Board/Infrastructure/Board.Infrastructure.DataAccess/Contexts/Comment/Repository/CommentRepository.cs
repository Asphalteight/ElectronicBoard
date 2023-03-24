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
    public async Task<bool> UpdateAsync(Comments model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model, cancellationToken);
        return true;
    }
    
    /// <inheritdoc/> 
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var model = _repository.GetAllFiltered(s => s.Id == id).FirstOrDefault();
        await _repository.DeleteAsync(model ?? throw new InvalidOperationException(), cancellationToken);
        return true;
    }
    
    /// <inheritdoc/> 
    public Task<InfoCommentDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _repository.GetAll().Where(s => s.Id == id)
            .ProjectTo<InfoCommentDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}