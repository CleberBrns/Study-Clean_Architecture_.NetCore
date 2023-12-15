using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductCategoryAsync(int id)
        {
            return await _context.Products.Include(x => x.Category)
                                          .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> InsertAsync(Product obj)
        {
            _context.Products.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Product> UpdateAsync(Product obj)
        {
            _context.Products.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Product> DeleteAsync(Product obj)
        {
            _context.Products.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
