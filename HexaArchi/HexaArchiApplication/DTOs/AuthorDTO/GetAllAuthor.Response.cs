using HexaArchi.Domain.Models;

namespace HexaArchi.Application.DTOs.AuthorDTO
{
    public class GetAllAuthorResponse
    {
        public IEnumerable<AuthorDto>? Authors { get; set; }

    }
    public class AuthorDto
    {
        public Guid AuthorId { get; set; }
        public required string Name { get; set; }
        public double Balance { get; set; }
    }
}
