using AutoMapper;
using Board.Application.AppData.Context.Account.Services;
using Board.Application.AppData.Context.Advertisement.Repositories;
using Board.Contracts.Contexts.Advertisements;
using Board.Domain.Advertisement;

namespace Board.Application.AppData.Context.Advertisement.Services;

/// <inheritdoc/>
public class AdvertisementService : IAdvertisementService
{
    private readonly IAdvertisementRepository _advertisementRepository;
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public AdvertisementService(IAdvertisementRepository advertisementRepository, IAccountService accountService, IMapper mapper)
    {
        _advertisementRepository = advertisementRepository;
        _accountService = accountService;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<int> CreateAdvertisementAsync(CreateAdvertisementDto model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CreateAdvertisementDto, Advertisements>(model);
        var currentUser = await _accountService.GetCurrentAsync(cancellationToken);

        if (currentUser?.Id == null)
        {
            return 0;
        }
        entity.AccountId = currentUser.Id;

        return await _advertisementRepository.CreateAsync(entity, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InfoAdvertisementDto?> UpdateAdvertisementAsync(int id, UpdateAdvertisementDto dto, CancellationToken cancellationToken)
    {
        var advertisement = await _advertisementRepository.GetByIdAsync(id, cancellationToken);
        if (advertisement == null) return null;
        var result = _mapper.Map(dto, advertisement);

        return await _advertisementRepository.UpdateAsync(result, cancellationToken);
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