using BookFetcher.Application.DTOs.BookDTO;
using BookFetcher.Domain.Models;

namespace BookFetcher.Application.Ports.Driving
{
    public interface IBookFactory
    {
        Book CreateBook(PostBookRequest request);
        PostBookResponse CreatePostBookResponse(Book book);
    }
}
