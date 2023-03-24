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
    public async Task<bool> UpdateAsync(Accounts model, CancellationToken cancellationToken)
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
    public Task<InfoAccountDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _repository.GetAll().Where(s => s.Id == id)
            .ProjectTo<InfoAccountDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}