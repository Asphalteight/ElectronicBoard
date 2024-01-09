using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Context.Advertisement.Repositories;
using Board.Contracts.Contexts.Advertisements;
using Board.Domain.Advertisement;
using Board.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
    public async Task<InfoAdvertisementDto> UpdateAsync(Advertisements model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model, cancellationToken);
        
        return _mapper.Map<Advertisements, InfoAdvertisementDto>(model);
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
    public async Task<Advertisements> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAll().Where(s => s.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
        
        return result;
    }

    public async Task<IEnumerable<InfoAdvertisementDto>> FindAsync(SearchAdvertisementDto dto, CancellationToken cancellationToken)
    {
        var allAdvertisements = _repository.GetAll().ProjectTo<InfoAdvertisementDto>(_mapper.ConfigurationProvider);

        if (string.IsNullOrEmpty(dto.Text))
        {
            return await allAdvertisements.Skip(dto.Skip).Take(dto.Take).ToListAsync(cancellationToken);
        }
        var bestMatch = allAdvertisements.Where(s => s.Title.Contains(dto.Text));
            
        var filteredDescription = allAdvertisements.Where(s => s.Description.Contains(dto.Text));
        bestMatch = filteredDescription.Count() > bestMatch.Count() ? filteredDescription : bestMatch;
            
        var filteredAddress = allAdvertisements.Where(s => s.Address.Contains(dto.Text));
        bestMatch = filteredAddress.Count() > bestMatch.Count() ? filteredAddress : bestMatch;

        return await bestMatch.ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoAdvertisementDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAll().ProjectTo<InfoAdvertisementDto>(_mapper.ConfigurationProvider).OrderBy(o => o.Id).ToListAsync(cancellationToken: cancellationToken);
    }
}