using AutoMapper;
using Board.Contracts.Contexts.Accounts;
using Board.Domain.Account;
using System;

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
                .ForMember(s => s.CreatedAt, map => map.MapFrom(s => DateTime.UtcNow))
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.AdvertisementsList, map => map.Ignore());

            CreateMap<Accounts, InfoAccountDto>();

            CreateMap<UpdateAccountDto, Accounts>()
                .ForMember(s => s.CreatedAt, map => map.Ignore())
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.AdvertisementsList, map => map.Ignore());
        }
    }
}
