using erp_likom_model.DTOs;
using erp_likom_model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_likom_business
{
    public interface IOrderProductService
    {
        Task<OrderProductDto> GetOrderProductByIdAsync(int id);   
        Task<IEnumerable<OrderProductDto>> GetOrderProductsByOrderIdAsync(int orderId);
        Task CreateOrderProductAsync(OrderProductDto orderProductDto);
        Task UpdateOrderProductAsync(OrderProductDto orderProductDto);
        Task DeleteOrderProductAsync(int id);
        Task<IEnumerable<OrderProductDto>> GetAllAsync();
    }
}
