using AutoMapper;
using Board.Application.AppData.Context.Subcategory.Repositories;
using Board.Contracts.Contexts.Subcategories;
using Board.Domain.Category;

namespace Board.Application.AppData.Context.Subcategory.Services;

/// <inheritdoc/>
public class SubcategoryService : ISubcategoryService
{
    private readonly ISubcategoryRepository _subcategoryRepository;
    private readonly IMapper _mapper;

    public SubcategoryService(ISubcategoryRepository subcategoryRepository, IMapper mapper)
    {
        _subcategoryRepository = subcategoryRepository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<int> CreateSubcategoryAsync(CreateSubcategoryDto model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CreateSubcategoryDto, Subcategories>(model);
        return await _subcategoryRepository.CreateAsync(entity, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InfoSubcategoryDto> UpdateSubcategoryAsync(int id, UpdateSubcategoryDto dto, CancellationToken cancellationToken)
    {
        var subcategory = await _subcategoryRepository.GetByIdAsync(id, cancellationToken);

        if (dto.Name != null) subcategory!.Name = dto.Name;
        if (dto.CategoryId != 0) subcategory!.CategoryId = dto.CategoryId;

        return await _subcategoryRepository.UpdateAsync(subcategory!, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteSubcategoryAsync(int id, CancellationToken cancellationToken)
    {
        var result = _subcategoryRepository.DeleteAsync(id, cancellationToken);
        return await result;
    }

    /// <inheritdoc/>
    public async Task<InfoSubcategoryDto?> GetSubcategoryByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _subcategoryRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<Subcategories?, InfoSubcategoryDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoSubcategoryDto>> GetAllSubcategories(CancellationToken cancellationToken)
    {
        var entities = _subcategoryRepository.GetAllAsync(cancellationToken);
        return await entities;
    }
}