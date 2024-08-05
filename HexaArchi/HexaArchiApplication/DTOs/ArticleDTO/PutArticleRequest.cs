using HexaArchi.Domain.Models;

namespace HexaArchi.Application.DTOs.ArticleDTO
{
    public class PutArticleRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public WritingStatus WritingStatus { get; set; }
        public Guid? AuthorId { get; set; }
    }
}
