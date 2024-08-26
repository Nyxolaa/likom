using erp_likom_model.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using erp_likom_data;

namespace erp_likom_repository.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly LikomDbContext _context;

        public OrderProductRepository(LikomDbContext context)
        {
            _context = context;
        }

        public async Task<OrderProduct> GetByIdAsync(int id)
        {
            return await _context.OrderProducts.FindAsync(id);
        }

        public async Task<IEnumerable<OrderProduct>> GetAllAsync()
        {
            return await _context.OrderProducts.ToListAsync();
        }

        public async Task<IEnumerable<OrderProduct>> GetByOrderIdAsync(int orderId)
        {
            return await _context.OrderProducts.Where(op => op.OrderId == orderId).ToListAsync();
        }

        public async Task AddAsync(OrderProduct orderProduct)
        {
            await _context.OrderProducts.AddAsync(orderProduct);
        }

        public async Task UpdateAsync(OrderProduct orderProduct)
        {
            _context.OrderProducts.Update(orderProduct);
        }

        public async Task DeleteAsync(int id)
        {
            var orderProduct = await _context.OrderProducts.FindAsync(id);
            if (orderProduct != null)
            {
                _context.OrderProducts.Remove(orderProduct);
            }
        }
    }
}
