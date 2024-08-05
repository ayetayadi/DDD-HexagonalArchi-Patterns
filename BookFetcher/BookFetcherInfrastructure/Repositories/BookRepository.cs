using BookFetcher.Application.Ports.Driven;
using BookFetcher.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookFetcher.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        #region Variable + Constructor
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Get All 
        public async Task<IEnumerable<Book>> GetAllAsync(int currentPage, int pageSize)
        {
            return await _dbContext.Books
                .AsNoTracking()
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        #endregion

        #region Get by ID

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Books
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion

        #region Add 
        public async Task AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region Delete
        public async Task DeleteAsync(Guid id)
        {
            Book? book = _dbContext.Books.FirstOrDefault(x => x.Id == id);

            if (book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion

        #region Get Total Count
        public async Task<int> GetTotalCountAsync()
        {
            return await _dbContext.Books.CountAsync();
        }
        #endregion
    }
}
