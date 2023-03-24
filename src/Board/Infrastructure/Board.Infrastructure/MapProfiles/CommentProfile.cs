using AutoMapper;
using Board.Contracts.Contexts.Comments;
using Board.Domain.Comment;

namespace Board.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль маппера для Comment (Комментария).
    /// </summary>
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CreateCommentDto, Comments>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.CreatedAt, map => map.MapFrom(s => DateTime.UtcNow))
                .ForMember(s => s.Account, map => map.Ignore())
                .ForMember(s => s.Advertisement, map => map.Ignore());

            CreateMap<Comments, CreateCommentDto>();
        }
    }
}
