﻿using AutoMapper;
using Board.Application.AppData.Context.ImageKit.Repositories;
using Board.Contracts.ImageKits;
using Board.Domain.ImageKit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Board.Application.AppData.Context.ImageKit.Services;

/// <inheritdoc/>
public class ImageKitService : IImageKitService
{
    private readonly IImageKitRepository _imageKitRepository;
    private readonly IMapper _mapper;

    public ImageKitService(IImageKitRepository imageKitRepository, IMapper mapper)
    {
        _imageKitRepository = imageKitRepository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<int> CreateImageKitAsync(CreateImageKitDto model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CreateImageKitDto, ImageKits>(model);

        return await _imageKitRepository.CreateAsync(entity, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InfoImageKitDto> UpdateImageKitAsync(int id, UpdateImageKitDto dto, CancellationToken cancellationToken)
    {
        var kit = await _imageKitRepository.GetByIdAsync(id, cancellationToken);
        if (kit == null)
        {
            return null;
        }
        
        var updated = _mapper.Map(dto, kit);
        
        return await _imageKitRepository.UpdateAsync(updated, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteImageKitAsync(int id, CancellationToken cancellationToken)
    {
        var result = _imageKitRepository.DeleteAsync(id, cancellationToken);
        
        return await result;
    }

    /// <inheritdoc/>
    public async Task<InfoImageKitDto> GetImageKitByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _imageKitRepository.GetByIdAsync(id, cancellationToken);
        
        return _mapper.Map<ImageKits, InfoImageKitDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoImageKitDto>> GetAllImageKits(CancellationToken cancellationToken)
    {
        var entities = _imageKitRepository.GetAllAsync(cancellationToken);
        
        return await entities;
    }
}