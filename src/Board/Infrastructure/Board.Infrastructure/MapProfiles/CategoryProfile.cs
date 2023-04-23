using AutoMapper;
using Board.Contracts.Contexts.Categories;
using Board.Domain.Category;

namespace Board.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль маппера для Category (Категории).
    /// </summary>
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Categories>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.AdvertisementsList, map => map.Ignore());

            CreateMap<Categories, InfoCategoryDto>();

            CreateMap<UpdateCategoryDto, Categories>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.AdvertisementsList, map => map.Ignore());
        }
    }
}
