using BookFetcher.Application.DTOs.BookDTO;
using BookFetcher.Application.Ports.Driving;
using BookFetcher.Domain.Models;

namespace BookFetcher.Application.Factory
{
    public class BookFactory : IBookFactory
    {
        public Book CreateBook(PostBookRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return new Book
            {
                Title = request.Title,
                Author = request.Author
            };
        }

        public PostBookResponse CreatePostBookResponse(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            return new PostBookResponse
            {
                BookId = book.Id,
                Title = book.Title,
                Author = book.Author
            };
        }
    }


}
