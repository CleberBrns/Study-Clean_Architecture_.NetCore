using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Domain.Entities;
using MediatR;
using CleanArchMvc.Application.CQRS.Products.Queries;

namespace CleanArchMvc.Application.CQRS.Products.Handlers
{
    public class GetProductCategoryHandler : IRequestHandler<GetProductCategoryQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductCategoryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductCategoryAsync(request.IdProduct);
        }
    }
}
