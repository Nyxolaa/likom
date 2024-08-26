using erp_likom_business;
using erp_likom_model.DTOs;
using erp_likom_model.Models;
using erp_likom_repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace erp_likom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var customer = await _service.GetCustomerByEmailAsync(email);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDto customer)
        {
            await _service.CreateCustomerAsync(customer);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customer)
        {
            if (id != customer.Id)
                return BadRequest();

            await _service.UpdateCustomerAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _service.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}
