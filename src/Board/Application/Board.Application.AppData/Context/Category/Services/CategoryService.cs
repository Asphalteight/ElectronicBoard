using AutoMapper;
using Board.Application.AppData.Context.Category.Repositories;
using Board.Contracts.Contexts.Categories;
using Board.Domain.Category;

namespace Board.Application.AppData.Context.Category.Services;

/// <inheritdoc/>
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<int> CreateCategoryAsync(CreateCategoryDto model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CreateCategoryDto, Categories>(model);
        
        return await _categoryRepository.CreateAsync(entity, cancellationToken);
    }
    
    /// <inheritdoc/>
    public async Task<InfoCategoryDto?> UpdateCategoryAsync(int id, UpdateCategoryDto dto, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        if (category == null)
        {
            return null;
        }
        
        var updated = _mapper.Map(dto, category);

        return await _categoryRepository.UpdateAsync(updated, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteCategoryAsync(int id, CancellationToken cancellationToken)
    {
        var result = _categoryRepository.DeleteAsync(id, cancellationToken);
        
        return await result;
    }

    /// <inheritdoc/>
    public async Task<InfoCategoryDto?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        
        return _mapper.Map<Categories?, InfoCategoryDto>(entity);
    }

    public async Task<IEnumerable<InfoCategoryDto>?> GetChildByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entities = _categoryRepository.GetChildByIdAsync(id, cancellationToken);
        
        return await entities;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoCategoryDto>> GetAllCategories(CancellationToken cancellationToken)
    {
        var entities = _categoryRepository.GetAllAsync(cancellationToken);
        
        return await entities;
    }
}