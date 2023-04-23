using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Context.ImageKit.Repositories;
using Board.Contracts.ImageKits;
using Board.Domain.ImageKit;
using Board.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Contexts.ImageKit.Repository;

/// <inheritdoc/> 
public class ImageKitRepository : IImageKitRepository
{
    private readonly IRepository<ImageKits> _repository;
    private readonly IMapper _mapper;
    
    public ImageKitRepository(IRepository<ImageKits> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/> 
    public async Task<int> CreateAsync(ImageKits model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model, cancellationToken);
        return model.AdvertisementId;
    }
    
    /// <inheritdoc/> 
    public async Task<InfoImageKitDto> UpdateAsync(ImageKits model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model, cancellationToken);
        return _mapper.Map<ImageKits, InfoImageKitDto>(model);
    }
    
    /// <inheritdoc/> 
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var model = _repository.GetAllFiltered(s => s.AdvertisementId == id).FirstOrDefault();
        if (model == null) return false;
        await _repository.DeleteAsync(model, cancellationToken);
        return true;
    }
    
    /// <inheritdoc/> 
    public async Task<ImageKits?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAll().Where(s => s.AdvertisementId == id)
            .FirstOrDefaultAsync(cancellationToken);
        return result;
    }
    
    /// <inheritdoc/>
    public async Task<IEnumerable<InfoImageKitDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAll().ProjectTo<InfoImageKitDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken: cancellationToken);
    }
}