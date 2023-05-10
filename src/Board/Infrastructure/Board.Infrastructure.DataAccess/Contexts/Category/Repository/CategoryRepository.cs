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
    public async Task<InfoCategoryDto> UpdateAsync(Categories model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model, cancellationToken);
        
        return _mapper.Map<Categories, InfoCategoryDto>(model);
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
    public async Task<Categories?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = _repository.GetAll().Where(s => s.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
        
        return await result;
    }

    public async Task<IEnumerable<InfoCategoryDto>?> GetChildByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = _repository.GetAll().ProjectTo<InfoCategoryDto>(_mapper.ConfigurationProvider).Where(s => s.ParentCategoryId == id).ToListAsync(cancellationToken);
        
        return await result;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoCategoryDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAll().ProjectTo<InfoCategoryDto>(_mapper.ConfigurationProvider).OrderBy(o => o.Id).ToListAsync(cancellationToken);
    }
}