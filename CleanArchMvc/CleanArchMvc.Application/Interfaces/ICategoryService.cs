using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task AddAsync(CategoryDto categoryDto);
        Task UpdateAsync(CategoryDto categoryDto);
        Task DeleteAsync(int id);
    }
}
