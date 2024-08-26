using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using erp_likom_data;
using erp_likom_model.Models;
using Microsoft.EntityFrameworkCore;

namespace erp_likom_repository.Repositories
{
    public interface IFinancialTransactionRepository : IRepository<FinancialTransaction>
    {
        Task<IEnumerable<FinancialTransaction>> GetByOrderIdAsync(int orderId);

    }
}
