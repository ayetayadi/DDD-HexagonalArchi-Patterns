using AutoMapper;
using HexaArchi.Application.DTOs.AuthorDTO;
using HexaArchi.Domain.Models;

namespace HexaArchi.Application.Mappings
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            // Map domain Author to AuthorDto
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)); 

            // Map AuthorDto to domain Author
            CreateMap<AuthorDto, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)); 

            // Map request DTO to domain model
            CreateMap<GetAuthorByIdRequest, Author>();
            CreateMap<PostAuthorRequest, Author>();
            CreateMap<PutAuthorRequest, Author>();

            // Map domain Author to response DTOs
            CreateMap<Author, GetAuthorByIdResponse>()
                .ForMember(dest => dest.Articles, opt => opt.MapFrom(src => src.Articles)); 

            CreateMap<Author, PostAuthorResponse>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)); 

            CreateMap<Author, PutAuthorResponse>();
              

            CreateMap<IEnumerable<Author>, GetAllAuthorResponse>()
                .ConvertUsing(src => new GetAllAuthorResponse
                {
                    Authors = src.Select(author => new AuthorDto
                    {
                        AuthorId = author.Id,
                        Name = author.Name,
                    }).ToList()
                });
        }
    }
}
