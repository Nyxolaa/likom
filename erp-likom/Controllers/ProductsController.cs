using erp_likom_business;
using erp_likom_model.DTOs;
using erp_likom_model.Models;
using erp_likom_repository.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace erp_likom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await _service.GetProductByNameAsync(name);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            var products = await _service.GetProductsByCategoryAsync(category);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto product)
        {
            await _service.CreateProductAsync(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto product)
        {
            if (id != product.Id)
                return BadRequest();

            await _service.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.DeleteProductAsync(id);
            return NoContent();
        }
    }

}
