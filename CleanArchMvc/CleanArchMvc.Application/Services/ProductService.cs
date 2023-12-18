using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using AutoMapper;
using CleanArchMvc.Application.CQRS.Products.Commands;
using CleanArchMvc.Application.CQRS.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var productQuery = new GetProductsQuery();
            var result = await _mediator.Send(productQuery);

            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var productQuery = new GetProductByIdQuery(id);

            var result = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDto>(result);
        }

        public async Task<ProductDto> GetProductCategoryAsync(int idProduct)
        {
            var productQuery = new GetProductCategoryQuery(idProduct);

            var result = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDto>(result);
        }

        public async Task AddAsync(ProductDto productDto)
        {
            var productCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCommand);
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var productCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productCommand);
        }

        public async Task DeleteAsync(int id)
        {
            var productCommand = new ProductRemoveCommand(id);
            await _mediator.Send(productCommand);
        }
    }
}
