using HexaArchi.Domain.Models;

namespace HexaArchi.Application.Ports.Driven
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(Guid id);
        Task AddAsync(Author author);
        Task UpdateAsync(Guid id, Author author);
        Task DeleteAsync(Guid id);
    }
}
