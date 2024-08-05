using BookFetcher.Application.DTOs.BookDTO;

namespace BookFetcher.Application.Ports.Driving
{
    public interface IBookService
    {
        Task<GetAllBookResponse> GetAllAsync(int currentPage, int pageSize);
        Task<GetBookByIdResponse?> GetByIdAsync(GetBookByIdRequest request);
        Task<PostBookResponse> AddAsync(PostBookRequest request);
        Task<DeleteBookResponse> DeleteAsync(DeleteBookRequest request);
    }
}
