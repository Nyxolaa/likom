using erp_likom_model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_likom_repository.Repositories
{
    public interface IOrderProductRepository : IRepository<OrderProduct>
    {
        Task<OrderProduct> GetByIdAsync(int id);
        Task<IEnumerable<OrderProduct>> GetAllAsync();
        Task<IEnumerable<OrderProduct>> GetByOrderIdAsync(int orderId);
        Task AddAsync(OrderProduct orderProduct);
        Task UpdateAsync(OrderProduct orderProduct);
        Task DeleteAsync(int id);
    }

}
