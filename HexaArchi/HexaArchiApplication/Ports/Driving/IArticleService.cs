using HexaArchi.Application.DTOs.ArticleDTO;
using HexaArchi.Application.DTOs.AuthorDTO;
using HexaArchi.Domain.Models;

namespace HexaArchi.Application.Ports.Driving
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleDto>> GetAllAsync();
        Task<GetArticleByIdResponse?> GetByIdAsync(GetArticleByIdRequest request);
        Task<PostArticleResponse> AddAsync(PostArticleRequest request);
        Task<PutArticleResponse> UpdateAsync(Guid id, PutArticleRequest request);
        Task<DeleteArticleResponse> DeleteAsync(DeleteArticleRequest request);
    }
}
