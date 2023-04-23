using AutoMapper;
using Board.Contracts.ImageKits;
using Board.Domain.ImageKit;

namespace Board.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль маппера для ImageKit (Набора изображений объявления).
    /// </summary>
    public class ImageKitProfile : Profile
    {
        public ImageKitProfile()
        {
            CreateMap<CreateImageKitDto, ImageKits>()
                .ForMember(s => s.Advertisement, map => map.Ignore());

            CreateMap<ImageKits, InfoImageKitDto>();

            CreateMap<UpdateImageKitDto, ImageKits>()
                .ForMember(s => s.Advertisement, map => map.Ignore())
                .ForMember(s => s.AdvertisementId, map => map.Ignore());
        }
    }
}
