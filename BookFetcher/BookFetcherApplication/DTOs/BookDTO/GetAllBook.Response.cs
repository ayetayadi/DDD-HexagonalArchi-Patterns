namespace BookFetcher.Application.DTOs.BookDTO
{
    public class GetAllBookResponse
    {
        public IEnumerable<BookDto>? Books { get; set; }

    }
    public class BookDto
    {
        public Guid BookId { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
    }
}
