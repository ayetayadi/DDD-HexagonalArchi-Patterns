using HexagonalDesignPatterns.Domain.Entities;

namespace HexagonalDesignPatterns.Application.Ports.Driven
{
    public interface ISmartphoneRepository
    {
        Task<IEnumerable<Smartphone>> GetAllAsync(int currentPage, int pageSize);
        Task<Smartphone> GetByIdAsync(int id);
        Task AddAsync(Smartphone smartphone);
        Task DeleteAsync(int id);
        Task<int> GetTotalCountAsync();
    }
}
