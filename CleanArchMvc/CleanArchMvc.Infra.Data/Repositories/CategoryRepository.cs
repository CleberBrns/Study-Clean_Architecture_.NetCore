using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> InsertAsync(Category obj)
        {
            _context.Categories.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            _context.Categories.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Category> DeleteAsync(Category obj)
        {
            _context.Categories.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
