using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var productsEntity = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(productsEntity);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(productEntity);
        }

        public async Task<ProductDto> GetProductCategoryAsync(int idProduct)
        {
            var productCategoryEntity = await _productRepository.GetProductCategoryAsync(idProduct);
            return _mapper.Map<ProductDto>(productCategoryEntity);
        }

        public async Task AddAsync(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.InsertAsync(productEntity);
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(productEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var productEntity = _productRepository.GetByIdAsync(id).Result;
            await _productRepository.DeleteAsync(productEntity);
        }
    }
}
