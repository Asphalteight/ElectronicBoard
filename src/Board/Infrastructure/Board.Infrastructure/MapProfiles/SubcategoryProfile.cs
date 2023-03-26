using AutoMapper;
using Board.Contracts.Contexts.Subcategories;
using Board.Domain.Category;

namespace Board.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль маппера для Subcategory (Подкатегории).
    /// </summary>
    public class SubcategoryProfile : Profile
    {
        public SubcategoryProfile()
        {
            CreateMap<CreateSubcategoryDto, Subcategories>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.Category, map => map.Ignore())
                .ForMember(s => s.AdvertisementsList, map => map.Ignore());
            
            CreateMap<Subcategories, InfoSubcategoryDto>();

            CreateMap<UpdateSubcategoryDto, Subcategories>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.Category, map => map.Ignore())
                .ForMember(s => s.AdvertisementsList, map => map.Ignore());
        }
    }
}
