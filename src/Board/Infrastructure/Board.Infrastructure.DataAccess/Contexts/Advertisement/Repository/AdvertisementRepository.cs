using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Context.Advertisement.Repositories;
using Board.Contracts.Contexts.Advertisements;
using Board.Domain.Advertisement;
using Board.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Contexts.Advertisement.Repository;

/// <inheritdoc/> 
public class AdvertisementRepository : IAdvertisementRepository
{
    private readonly IRepository<Advertisements> _repository;
    private readonly IMapper _mapper;
    
    public AdvertisementRepository(IRepository<Advertisements> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/> 
    public async Task<int> CreateAsync(Advertisements model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model, cancellationToken);
        return model.Id;
    }
    
    /// <inheritdoc/> 
    public async Task<bool> UpdateAsync(Advertisements model, CancellationToken cancellationToken)
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
    public Task<InfoAdvertisementDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _repository.GetAll().Where(s => s.Id == id)
            .ProjectTo<InfoAdvertisementDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}