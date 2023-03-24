using AutoMapper;
using Board.Contracts.Contexts.Messages;
using Board.Domain.Message;

namespace Board.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль маппера для Message (Сообщения).
    /// </summary>
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<CreateMessageDto, Messages>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.SentAt, map => map.MapFrom(s => DateTime.UtcNow));

            CreateMap<Messages, CreateMessageDto>();
        }
    }
}
