using HexaArchi.Domain.Models;
using HexaArchi.Application.Ports.Driven;
using Microsoft.EntityFrameworkCore;
using HexaArchi.Infrastructure.Data;

namespace HexaArchi.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        #region Variable+ Constructor

        private readonly AppDbContext _dbContext;

        public ArticleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region GetAll
        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _dbContext.Articles.AsNoTracking().ToListAsync();
        }
        #endregion

        #region GetBYId
        public async Task<Article?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Articles
                .Include(a => a.Author)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        #endregion

        #region Add

        public async Task AddAsync(Article article)
        {
            Author? existingAuthor = await _dbContext.Authors.FindAsync(article.AuthorId);

            if (existingAuthor == null)
            {
                throw new InvalidOperationException("Author not found.");
            }
            await _dbContext.Articles.AddAsync(article);
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region Update

        public async Task UpdateAsync(Guid id, Article article)
        {
            Article? existingArticle = await _dbContext.Articles.FindAsync(id);

            if (existingArticle == null)
            {
                throw new InvalidOperationException("Article not found.");
            }

            _dbContext.Articles.Entry(existingArticle).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region Delete
        public async Task DeleteAsync(Guid id)
        {
            Article? article = await _dbContext.Articles.FirstOrDefaultAsync(x => x.Id == id);

            if (article != null)
            {
                _dbContext.Articles.Remove(article);
                await _dbContext.SaveChangesAsync();
            }
        }

        #endregion
    }
}
