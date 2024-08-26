using erp_likom_business;
using erp_likom_model.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace erp_likom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialTransactionController : ControllerBase
    {
        private readonly IFinancialTransactionService _service;

        public FinancialTransactionController(IFinancialTransactionService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialTransactionDto>> GetByIdAsync(int id)
        {
            var transaction = await _service.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<IEnumerable<FinancialTransactionDto>>> GetByOrderIdAsync(int orderId)
        {
            var transactions = await _service.GetByOrderIdAsync(orderId);
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] FinancialTransactionCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] FinancialTransactionDto dto)
        {
            dto.Id = id;
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
