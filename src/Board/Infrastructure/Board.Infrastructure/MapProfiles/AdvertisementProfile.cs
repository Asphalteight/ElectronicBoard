using AutoMapper;
using Board.Contracts.Contexts.Advertisements;
using Board.Domain.Advertisement;

namespace Board.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль маппера для Advertisement (Объявления).
    /// </summary>
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<CreateAdvertisementDto, Advertisements>()
                .ForMember(s => s.CreatedAt, map => map.MapFrom(s => DateTime.UtcNow))
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.Account, map => map.Ignore())
                .ForMember(s => s.Subcategory, map => map.Ignore())
                .ForMember(s => s.CommentsList, map => map.Ignore());
            
            CreateMap<Advertisements, CreateAdvertisementDto>();
        }
    }
}
