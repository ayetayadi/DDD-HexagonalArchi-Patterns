using AutoMapper;
using HexaArchi.Application.DTOs.WritingDTO;
using HexaArchi.Domain.Models;

namespace HexaArchi.Application.Mappings
{
    public class WritingMappingProfile : Profile
    {
        public WritingMappingProfile()
        {
            CreateMap<ChangeArticleStatusRequest, Article>()
                .ForMember(dest => dest.WritingStatus, opt => opt.MapFrom(src => src.WritingStatus));

            CreateMap<StartWritingRequest, Article>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId));

            CreateMap<Article, ChangeArticleStatusResponse>();

            CreateMap<Article, StartWritingResponse>();
        }
    }
}
