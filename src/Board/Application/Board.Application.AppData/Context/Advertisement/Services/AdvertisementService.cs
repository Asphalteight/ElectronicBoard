using AutoMapper;
using Board.Application.AppData.Context.Account.Services;
using Board.Application.AppData.Context.Advertisement.Repositories;
using Board.Application.AppData.Context.ImageKit.Services;
using Board.Contracts.Contexts.Advertisements;
using Board.Contracts.ImageKits;
using Board.Domain.Advertisement;

namespace Board.Application.AppData.Context.Advertisement.Services;

/// <inheritdoc/>
public class AdvertisementService : IAdvertisementService
{
    private readonly IAdvertisementRepository _advertisementRepository;
    private readonly IAccountService _accountService;
    private readonly IImageKitService _imageKitService;
    private readonly IMapper _mapper;

    public AdvertisementService(IAdvertisementRepository advertisementRepository, IAccountService accountService, IImageKitService imageKitService, IMapper mapper)
    {
        _advertisementRepository = advertisementRepository;
        _accountService = accountService;
        _imageKitService = imageKitService;
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

        var advertId = await _advertisementRepository.CreateAsync(entity, cancellationToken);
        await _imageKitService.CreateImageKitAsync(new CreateImageKitDto()
        {
            AdvertisementId = advertId
        }, cancellationToken);
        
        return advertId;
    }

    /// <inheritdoc/>
    public async Task<InfoAdvertisementDto?> UpdateAdvertisementAsync(int id, UpdateAdvertisementDto dto, CancellationToken cancellationToken)
    {
        var advertisement = await _advertisementRepository.GetByIdAsync(id, cancellationToken);
        if (advertisement == null)
        {
            return null;
        }
        
        var updated = _mapper.Map(dto, advertisement);

        return await _advertisementRepository.UpdateAsync(updated, cancellationToken);
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

    public async Task<IEnumerable<InfoAdvertisementDto?>> FindAdvertisementAsync(SearchAdvertisementDto dto, CancellationToken cancellationToken)
    {
        var result = _advertisementRepository.FindAsync(dto, cancellationToken);

        return await result;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoAdvertisementDto>> GetAllAdvertisements(CancellationToken cancellationToken)
    {
        var entities = _advertisementRepository.GetAllAsync(cancellationToken);
        
        return await entities;
    }
}