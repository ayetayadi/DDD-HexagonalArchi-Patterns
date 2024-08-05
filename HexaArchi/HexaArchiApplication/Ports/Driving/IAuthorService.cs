using HexaArchi.Application.DTOs.AuthorDTO;
using HexaArchi.Domain.Models;

namespace HexaArchi.Application.Ports.Driving
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<GetAuthorByIdResponse?> GetByIdAsync(GetAuthorByIdRequest request);
        Task<PostAuthorResponse> AddAsync(PostAuthorRequest request);
        Task<PutAuthorResponse> UpdateAsync(Guid id, PutAuthorRequest request);
        Task<DeleteAuthorResponse> DeleteAsync(DeleteAuthorRequest request);
    }
}
