using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Context.Category.Repositories;
using Board.Contracts.Contexts.Categories;
using Board.Domain.Category;
using Board.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Contexts.Category.Repository;

/// <inheritdoc/> 
public class CategoryRepository : ICategoryRepository
{
    private readonly IRepository<Categories> _repository;
    private readonly IMapper _mapper;
    
    public CategoryRepository(IRepository<Categories> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/> 
    public async Task<int> CreateAsync(Categories model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model, cancellationToken);
        return model.Id;
    }
    
    /// <inheritdoc/> 
    public async Task<bool> UpdateAsync(Categories model, CancellationToken cancellationToken)
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
    public Task<InfoCategoryDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _repository.GetAll().Where(s => s.Id == id)
            .ProjectTo<InfoCategoryDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}