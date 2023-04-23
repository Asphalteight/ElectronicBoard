using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Board.Application.AppData.Context.Account.Repositories;
using Board.Contracts.Contexts.Accounts;
using Board.Domain.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Board.Application.AppData.Context.Account.Services;

/// <inheritdoc/>
public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public AccountService(IAccountRepository accountRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
    }

     /// <inheritdoc />
    public async Task<int> RegisterAccountAsync(CreateAccountDto accountDto, CancellationToken cancellation)
    {
        var account = new Accounts
        {
            
            Name = accountDto.Name,
            Email = accountDto.Email,
            Phone = accountDto.Phone,
            Password = accountDto.Password,
        };

        var existingAccount = await _accountRepository.FindWhere(acc => acc.Email == accountDto.Email, cancellation);
        if (existingAccount != null)
        {
            throw new Exception($"Пользователь с Email '{accountDto.Email}' уже зарегистрирован!");
        }
        
        await _accountRepository.CreateAsync(account, cancellation);

        return account.Id;
    }

    /// <inheritdoc />
    public async Task<string> LoginAsync(LoginAccountDto accountDto, CancellationToken cancellation)
    {
        var existingAccount = await _accountRepository.FindWhere(account => account.Email == accountDto.Email, cancellation);
        if (existingAccount == null)
        {
            throw new Exception("Пользователь не найден!");
        }

        if (!existingAccount.Password.Equals(accountDto.Password))
        {
            throw new Exception("Неверная почта или пароль.");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, existingAccount.Id.ToString()),
            new Claim(ClaimTypes.Name, existingAccount.Email)
        };

        var key = _configuration["Jwt:Key"];

        var token = new JwtSecurityToken
            (
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256
                )
            );

        var result = new JwtSecurityTokenHandler().WriteToken(token);

        return result;
    }

    /// <inheritdoc />
    public async Task<InfoAccountDto> GetCurrentAsync(CancellationToken cancellation)
    {
        var claims = _httpContextAccessor.HttpContext?.User.Claims;
        var claimId = claims!.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(claimId))
        {
            return null;
        }

        var id = int.Parse(claimId);
        var user = await _accountRepository.GetByIdAsync(id, cancellation);

        if (user == null) {
            throw new Exception($"Не найден пользователь с идентификатором '{id}'.");
        }

        //TO DO какой-то "тодо" здесь
        var  result = new InfoAccountDto
        {
            Id = user.Id,
            Email = user.Email
        };

        return result;
    }

    /// <inheritdoc/>
    public async Task<InfoAccountDto> UpdateAccountAsync(int id, UpdateAccountDto dto, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetByIdAsync(id, cancellationToken);

        if (dto.Name != null) account!.Name = dto.Name; 
        if (dto.Email != null) account!.Email = dto.Email; 
        if (dto.Phone != null) account!.Phone = dto.Phone; 
        if (dto.Password != null) account!.Password = dto.Password; 

        return await _accountRepository.UpdateAsync(account!, cancellationToken);
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
        var entity = await _accountRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<Accounts?, InfoAccountDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<InfoAccountDto>> GetAllAccounts(CancellationToken cancellationToken)
    {
        var entities = _accountRepository.GetAllAsync(cancellationToken);
        return await entities;
    }
}