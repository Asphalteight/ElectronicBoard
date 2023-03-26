using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Context.Account.Repositories;
using Board.Contracts.Contexts.Accounts;
using Board.Domain.Account;
using Board.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Contexts.Account.Repository;

/// <inheritdoc/> 
public class AccountRepository : IAccountRepository
{
    private readonly IRepository<Accounts> _repository;
    private readonly IMapper _mapper;
    
    public AccountRepository(IRepository<Accounts> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/> 
    public async Task<int> CreateAsync(Accounts model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model, cancellationToken);
        return model.Id;
    }
    
    /// <inheritdoc/> 
    public async Task<InfoAccountDto> UpdateAsync(Accounts model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model, cancellationToken);
        return _mapper.Map<Accounts, InfoAccountDto>(model);
    }
    
    /// <inheritdoc/> 
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var model = _repository.GetAllFiltered(s => s.Id == id).FirstOrDefault();
        if (model == null) return false;
        await _repository.DeleteAsync(model, cancellationToken);
        return true;
    }
    
    /// <inheritdoc/> 
    public async Task<Accounts?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
         var result = await _repository.GetAll().Where(s => s.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
         return result;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoAccountDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAll().ProjectTo<InfoAccountDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken: cancellationToken);
    }
}