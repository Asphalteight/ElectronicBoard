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
                .ForMember(s => s.SentAt, map => map.MapFrom(s => DateTime.UtcNow))
                .ForMember(s => s.IsRead, map => map.Ignore());
            
            CreateMap<Messages, InfoMessageDto>();

            CreateMap<UpdateMessageDto, Messages>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.SentAt, map => map.Ignore())
                .ForMember(s => s.Sender, map => map.Ignore())
                .ForMember(s => s.Receiver, map => map.Ignore());
        }
    }
}
