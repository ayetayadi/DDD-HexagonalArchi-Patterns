namespace BookFetcher.Application.DTOs.BookDTO
{
    public class GetBookByIdResponse
    {
        public required string Title { get; set; }
        public required string Author { get; set; }

    }
}
