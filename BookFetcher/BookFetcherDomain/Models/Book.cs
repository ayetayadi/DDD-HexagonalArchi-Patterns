using BookFetcher.SharedKarnel.Entities;

namespace BookFetcher.Domain.Models
{
    public class Book : BaseEntity
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
    }
}
