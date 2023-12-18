using AutoMapper;
using CleanArchMvc.Application.CQRS.Products.Commands;
using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Mappings
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateMap<ProductDto, ProductCreateCommand>();
            CreateMap<ProductDto, ProductUpdateCommand>();
        }
    }
}
