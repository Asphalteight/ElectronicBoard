using AutoMapper;
using Board.Application.AppData.Context.Advertisement.Repositories;
using Board.Contracts.Contexts.Advertisements;
using Board.Domain.Advertisement;

namespace Board.Application.AppData.Context.Advertisement.Services;

/// <inheritdoc/>
public class AdvertisementService : IAdvertisementService
{
    private readonly IAdvertisementRepository _advertisementRepository;
    private readonly IMapper _mapper;

    public AdvertisementService(IAdvertisementRepository advertisementRepository, IMapper mapper)
    {
        _advertisementRepository = advertisementRepository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<int> CreateAdvertisementAsync(CreateAdvertisementDto model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CreateAdvertisementDto, Advertisements>(model);
        return await _advertisementRepository.CreateAsync(entity, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InfoAdvertisementDto?> UpdateAdvertisementAsync(int id, UpdateAdvertisementDto dto, CancellationToken cancellationToken)
    {
        var advertisement = await _advertisementRepository.GetByIdAsync(id, cancellationToken);
        if (advertisement == null) return null;
        if (dto.Title != null) advertisement!.Title = dto.Title;
        if (dto.Description != null) advertisement!.Description = dto.Description;
        if (dto.Price != 0) advertisement!.Price = dto.Price;
        if (dto.IsActive != true) advertisement!.IsActive = dto.IsActive;

        return await _advertisementRepository.UpdateAsync(advertisement!, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAdvertisementAsync(int id, CancellationToken cancellationToken)
    {
        var result = _advertisementRepository.DeleteAsync(id, cancellationToken);
        return await result;
    }

    /// <inheritdoc/>
    public async Task<InfoAdvertisementDto?> GetAdvertisementByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _advertisementRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<Advertisements?, InfoAdvertisementDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoAdvertisementDto>> GetAllAdvertisements(CancellationToken cancellationToken)
    {
        var entities = _advertisementRepository.GetAllAsync(cancellationToken);
        return await entities;
    }
}