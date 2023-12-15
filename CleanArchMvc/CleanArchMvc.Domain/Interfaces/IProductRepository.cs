using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository : Base.IRepository<Product>
    {
        Task<Product> GetProductCategoryAsync(int id);
    }
}
