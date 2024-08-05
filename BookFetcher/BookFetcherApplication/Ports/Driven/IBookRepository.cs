using BookFetcher.Domain.Models;

namespace BookFetcher.Application.Ports.Driven
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync(int currentPage, int pageSize);
        Task<Book?> GetByIdAsync(Guid id);
        Task AddAsync(Book book);
        Task DeleteAsync(Guid id);
        Task<int> GetTotalCountAsync();
    }
}
