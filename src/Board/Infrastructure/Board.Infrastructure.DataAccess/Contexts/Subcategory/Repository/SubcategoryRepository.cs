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
    public async Task<InfoSubcategoryDto> UpdateAsync(Subcategories model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model, cancellationToken);
        return _mapper.Map<Subcategories, InfoSubcategoryDto>(model);
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
    public async Task<Subcategories?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = _repository.GetAll().Where(s => s.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
        return await result;
    }
    
    /// <inheritdoc/>
    public async Task<IEnumerable<InfoSubcategoryDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAll().ProjectTo<InfoSubcategoryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken: cancellationToken);
    }
}