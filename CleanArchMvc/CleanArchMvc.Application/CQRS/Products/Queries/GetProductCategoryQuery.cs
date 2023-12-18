using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.CQRS.Products.Queries
{
    public class GetProductCategoryQuery : IRequest<Product>
    {
        public int IdProduct { get; set; }

        public GetProductCategoryQuery(int idProduct)
        {
            IdProduct = idProduct;
        }
    }

}
