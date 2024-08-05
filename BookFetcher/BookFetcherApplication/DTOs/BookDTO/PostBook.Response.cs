namespace BookFetcher.Application.DTOs.BookDTO
{
    public class PostBookResponse
    {
        public Guid BookId { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
    }
}
