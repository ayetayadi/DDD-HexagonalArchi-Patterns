using AutoMapper;
using HexaArchi.Application.DTOs.ArticleDTO;
using HexaArchi.Application.DTOs.AuthorDTO;
using HexaArchi.Domain.Models;

namespace HexaArchi.Application.Mappings
{
    public class ArticleMappingProfile : Profile
    {
        public ArticleMappingProfile()
        {
            CreateMap<Article, ArticleDto>()
                .ForMember(dest => dest.ArticleId, opt => opt.MapFrom(src => src.Id));

            CreateMap<ArticleDto, Article>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ArticleId));

            CreateMap<GetArticleByIdRequest, Article>();
            CreateMap<Article, GetArticleByIdResponse>();

            CreateMap<PostArticleRequest, Article>();
            CreateMap<Article, PostArticleResponse>()
                .ForMember(dest => dest.ArticleId, opt => opt.MapFrom(src => src.Id));

            CreateMap<PutArticleRequest, Article>();
            CreateMap<Article, PutArticleResponse>();
        }
    }
}
