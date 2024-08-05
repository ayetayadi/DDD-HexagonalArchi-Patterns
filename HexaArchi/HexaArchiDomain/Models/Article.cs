using HexaArchi.SharedKarnel.Entities;

namespace HexaArchi.Domain.Models
{
    public class Article : BaseEntity
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public WritingStatus WritingStatus { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
