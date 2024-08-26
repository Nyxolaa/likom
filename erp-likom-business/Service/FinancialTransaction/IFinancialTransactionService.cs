using erp_likom_model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_likom_business
{
    public interface IFinancialTransactionService
    {
        Task<FinancialTransactionDto> GetByIdAsync(int id);
        Task<IEnumerable<FinancialTransactionDto>> GetByOrderIdAsync(int orderId);
        Task CreateAsync(FinancialTransactionCreateDto dto);
        Task UpdateAsync(FinancialTransactionDto dto);
        Task DeleteAsync(int id);
    }
}
