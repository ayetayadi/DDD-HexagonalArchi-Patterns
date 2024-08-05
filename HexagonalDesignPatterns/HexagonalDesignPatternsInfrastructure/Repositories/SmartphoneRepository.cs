using HexagonalDesignPatterns.Application.Ports.Driven;
using HexagonalDesignPatterns.Domain.Entities;
using HexagonalDesignPatterns.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HexagonalDesignPatterns.Infrastructure.Repositories
{
    public class SmartphoneRepository : ISmartphoneRepository
    {
        private readonly AppDbContext _context;

        public SmartphoneRepository(AppDbContext context)
        {
            _context = context;
        }

        #region GetAll
        public async Task<IEnumerable<Smartphone>> GetAllAsync(int currentPage, int pageSize)
        {
            return await _context.Smartphones
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        #endregion

        #region GetByid
        public async Task<Smartphone?> GetByIdAsync(int id)
        {
            return await _context.Smartphones.FindAsync(id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Smartphones.CountAsync();
        }
        #endregion

        #region Add
        public async Task AddAsync(Smartphone smartphone)
        {
            await _context.Smartphones.AddAsync(smartphone);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public async Task DeleteAsync(int id)
        {
            var smartphone = await _context.Smartphones.FindAsync(id);
            if (smartphone != null)
            {
                _context.Smartphones.Remove(smartphone);
                await _context.SaveChangesAsync();
            }
        }

        #endregion
    }
}
