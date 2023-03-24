using AutoMapper;
using Board.Contracts.Contexts.Accounts;
using Board.Domain.Account;

namespace Board.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль маппера для Account (Аккаунта).
    /// </summary>
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountDto, Accounts>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.AdvertisementsList, map => map.Ignore());

            CreateMap<Accounts, CreateAccountDto>();
        }
    }
}
