using AutoMapper;
using Board.Contracts.File;
using Board.Contracts.Files;
using Board.Domain.File;

namespace Board.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль работы с файлами.
    /// </summary>
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<FileDto, Files>(MemberList.None)
                .ForMember(d => d.Length, map => map.MapFrom(s => s.Content.Length))
                .ForMember(d => d.CreatedAt, map => map.MapFrom(s => DateTime.UtcNow));

            CreateMap<Files, FileDto>(MemberList.None);

            CreateMap<Files, FileInfoDto>(MemberList.None);
        }
    }
}
