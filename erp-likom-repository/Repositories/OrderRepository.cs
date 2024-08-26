using erp_likom_model.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using erp_likom_data;

namespace erp_likom_repository.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly LikomDbContext _context;

        public OrderRepository(LikomDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Set<Order>()
                                 .Where(o => o.CustomerId == customerId)
                                 .ToListAsync();
        }
    }
}
