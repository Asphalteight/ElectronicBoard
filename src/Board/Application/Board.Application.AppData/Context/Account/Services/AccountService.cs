using AutoMapper;
using Board.Application.AppData.Context.Account.Repositories;
using Board.Contracts.Contexts.Accounts;
using Board.Domain.Account;

namespace Board.Application.AppData.Context.Account.Services;

/// <inheritdoc/>
public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public AccountService(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<int> CreateAccountAsync(CreateAccountDto model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CreateAccountDto, Accounts>(model);
        return await _accountRepository.CreateAsync(entity, cancellationToken);
    }
    
    /// <inheritdoc/>
    public async Task<InfoAccountDto> ReplaceAccountAsync(int id, ReplaceAccountDto dto,
        CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ReplaceAccountDto, Accounts>(dto);
        entity.Id = id;
        return await _accountRepository.UpdateAsync(entity, cancellationToken);
    }
    
    /// <inheritdoc/>
    public async Task<InfoAccountDto> UpdateAccountAsync(int id, UpdateAccountDto dto, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetByIdAsync(id, cancellationToken);

        if (dto.Name != null) account!.Name = dto.Name; 
        if (dto.Email != null) account!.Email = dto.Email; 
        if (dto.Phone != null) account!.Phone = dto.Phone; 
        if (dto.Password != null) account!.Password = dto.Password; 

        return await _accountRepository.UpdateAsync(account, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAccountAsync(int id, CancellationToken cancellationToken)
    {
        var result = _accountRepository.DeleteAsync(id, cancellationToken);
        return await result;
    }

    /// <inheritdoc/>
    public async Task<InfoAccountDto?> GetAccountByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = _accountRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<Accounts?, InfoAccountDto>(await entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoAccountDto>> GetAllAccounts(CancellationToken cancellationToken)
    {
        var entities = _accountRepository.GetAllAsync(cancellationToken);
        return await entities;
    }
}