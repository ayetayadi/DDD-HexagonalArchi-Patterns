using HexaArchi.Domain.Models;

namespace HexaArchi.Application.DTOs.AuthorDTO
{
    public class PostAuthorResponse
    {
        public Guid AuthorId { get; set; }
        public required string Name { get; set; }
        public double Balance { get; set; }
        public ICollection<Article>? Articles { get; set; }
    }
}
