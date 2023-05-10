using AutoMapper;
using Board.Application.AppData.Context.Comment.Repositories;
using Board.Contracts.Contexts.Comments;
using Board.Domain.Comment;

namespace Board.Application.AppData.Context.Comment.Services;

/// <inheritdoc/>
public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<int> CreateCommentAsync(CreateCommentDto model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CreateCommentDto, Comments>(model);
        
        return await _commentRepository.CreateAsync(entity, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InfoCommentDto?> UpdateCommentAsync(int id, UpdateCommentDto dto, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(id, cancellationToken);
        if (comment == null)
        {
            return null;
        }
        
        var updated = _mapper.Map(dto, comment);

        return await _commentRepository.UpdateAsync(updated, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteCommentAsync(int id, CancellationToken cancellationToken)
    {
        var result = _commentRepository.DeleteAsync(id, cancellationToken);
        
        return await result;
    }

    /// <inheritdoc/>
    public async Task<InfoCommentDto?> GetCommentByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _commentRepository.GetByIdAsync(id, cancellationToken);
        
        return _mapper.Map<Comments?, InfoCommentDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoCommentDto>> GetAllComments(CancellationToken cancellationToken)
    {
        var entities = _commentRepository.GetAllAsync(cancellationToken);
        
        return await entities;
    }
}