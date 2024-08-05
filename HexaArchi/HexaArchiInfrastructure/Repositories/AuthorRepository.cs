using HexaArchi.Domain.Models;
using HexaArchi.Application.Ports.Driven;
using Microsoft.EntityFrameworkCore;
using HexaArchi.Infrastructure.Data;

namespace HexaArchi.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        #region Variable + Constructor

        private readonly AppDbContext _dbContext;

        public AuthorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region GetAll

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _dbContext.Authors.AsNoTracking().ToListAsync();
        }
        #endregion

        #region GetById
        public async Task<Author?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Authors
                .Include(a => a.Articles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion

        #region Add

        public async Task AddAsync(Author author)
        {
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region Update
        public async Task UpdateAsync(Guid id, Author author)
        {
            Author? existingAuthor = await _dbContext.Authors.FindAsync(id);

            if (existingAuthor == null)
            {
                throw new InvalidOperationException("Author not found!!!");
            }

            _dbContext.Authors.Entry(existingAuthor).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region Delete
        public async Task DeleteAsync(Guid id)
        {
            Author? author = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if (author != null)
            {
                _dbContext.Authors.Remove(author);
                await _dbContext.SaveChangesAsync();
            }
        }

        #endregion
    }
}
