using HexaArchi.Application.DTOs.ArticleDTO;
using HexaArchi.Domain.Models;

namespace HexaArchi.Application.DTOs.AuthorDTO
{
    public class GetAuthorByIdResponse
    {
        public required string Name { get; set; }
        public double Balance { get; set; }
        public List<GetArticleByIdResponse> Articles { get; set; } = new List<GetArticleByIdResponse>();

    }
}
