using erp_likom_model.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace erp_likom_business
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId);
        Task CreateOrderAsync(OrderCreateDto OrderDto);
        Task UpdateOrderAsync(OrderDto OrderDto);
        Task DeleteOrderAsync(int id);
        Task<bool> ProcessOrderAsync(int orderId);
    }
}
