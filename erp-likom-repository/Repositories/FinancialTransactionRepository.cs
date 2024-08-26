using erp_likom_data;
using erp_likom_model.Models;
using Microsoft.EntityFrameworkCore;

namespace erp_likom_repository.Repositories
{
    public class FinancialTransactionRepository  : Repository<FinancialTransaction>, IFinancialTransactionRepository 
    {
        private readonly LikomDbContext _context;

        public FinancialTransactionRepository (LikomDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FinancialTransaction>> GetByOrderIdAsync(int orderId)
        {
            return await _context.Set<FinancialTransaction>()
                                 .Where(ft => ft.OrderId == orderId)
                                 .ToListAsync();
        }
    }
}
