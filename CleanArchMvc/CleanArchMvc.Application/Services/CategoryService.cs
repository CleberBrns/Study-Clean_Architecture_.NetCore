using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task AddAsync(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.InsertAsync(categoryEntity);
        }

        public async Task UpdateAsync(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var categoryEntity = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.DeleteAsync(categoryEntity);
        }
    }
}
