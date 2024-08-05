using HexaArchi.Domain.Models;

namespace HexaArchi.Application.Ports.Driven
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article?> GetByIdAsync(Guid id);
        Task AddAsync(Article article);
        Task UpdateAsync(Guid id, Article article);
        Task DeleteAsync(Guid id);
    }
}
