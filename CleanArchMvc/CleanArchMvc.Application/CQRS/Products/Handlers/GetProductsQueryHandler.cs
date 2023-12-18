using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Domain.Entities;
using MediatR;
using CleanArchMvc.Application.CQRS.Products.Queries;

namespace CleanArchMvc.Application.CQRS.Products.Handlers
{
    internal class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
