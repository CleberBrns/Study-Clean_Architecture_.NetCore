using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await _productService.GetProductsAsync();

            if (products == null || !products.Any())
            {
                return NotFound("Products not found.");
            }

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDto product)
        {
            if (product == null)
            {
                return BadRequest("Invalid Data.");
            }

            await _productService.AddAsync(product);

            return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductDto product)
        {
            if (product == null)
            {
                return BadRequest("Invalid Data.");
            }

            await _productService.UpdateAsync(product);

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return BadRequest("Product Not Found.");
            }
            else
            {
                await _productService.DeleteAsync(id);

                return Ok();
            }
        }

    }
}
