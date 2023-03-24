using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Context.Subcategory.Repositories;
using Board.Contracts.Contexts.Subcategories;
using Board.Domain.Category;
using Board.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Contexts.Subcategory.Repository;

/// <inheritdoc/> 
public class SubcategoryRepository : ISubcategoryRepository
{
    private readonly IRepository<Subcategories> _repository;
    private readonly IMapper _mapper;
    
    public SubcategoryRepository(IRepository<Subcategories> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/> 
    public async Task<int> CreateAsync(Subcategories model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model, cancellationToken);
        return model.Id;
    }
    
    /// <inheritdoc/> 
    public async Task<bool> UpdateAsync(Subcategories model, CancellationToken cancellationToken)
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
    public Task<InfoSubcategoryDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _repository.GetAll().Where(s => s.Id == id)
            .ProjectTo<InfoSubcategoryDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}