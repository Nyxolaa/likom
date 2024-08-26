using erp_likom_business;
using erp_likom_model.DTOs;
using erp_likom_model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace erp_likom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly IOrderProductService _service;

        public OrderProductController(IOrderProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderProductDto>> GetByIdAsync(int id)
        {
            var orderProduct = await _service.GetOrderProductByIdAsync(id);
            if (orderProduct == null)
            {
                return NotFound();
            }
            return Ok(orderProduct); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderProductDto>>> GetAllAsync()
        {
            var orderProducts = await _service.GetAllAsync();
            return Ok(orderProducts); 
        }

        [HttpGet("byOrder/{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderProductDto>>> GetByOrderIdAsync(int orderId)
        {
            var orderProducts = await _service.GetOrderProductByIdAsync(orderId);
            return Ok(orderProducts); 
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] OrderProductDto dto)
        {
            await _service.CreateOrderProductAsync(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] OrderProductDto dto)
        {
            dto.Id = id;
            await _service.UpdateOrderProductAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _service.DeleteOrderProductAsync(id);
            return NoContent();
        }
    }
}
