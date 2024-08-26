using erp_likom_model.DTOs;
using erp_likom_model.Models;
using erp_likom_repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_likom_business
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            return MapToDTO(order);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return orders.Select(MapToDTO);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId)
        {
            var orders = await _unitOfWork.Orders.GetOrdersByCustomerIdAsync(customerId);
            return orders.Select(MapToDTO);
        }

        public async Task CreateOrderAsync(OrderCreateDto OrderDto)
        {
            var order = MapToModel(OrderDto);
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateOrderAsync(OrderDto OrderDto)
        {
            var order = MapToModel(OrderDto);
            await _unitOfWork.Orders.UpdateAsync(order);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _unitOfWork.Orders.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ProcessOrderAsync(int orderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null) return false;

            await _unitOfWork.Orders.UpdateAsync(order);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        private OrderDto MapToDTO(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,

            };
        }

        private Order MapToModel(OrderDto OrderDto)
        {
            return new Order
            {
                Id = OrderDto.Id,
                CustomerId = OrderDto.CustomerId,
                OrderDate = OrderDto.OrderDate,
                TotalAmount = OrderDto.TotalAmount,
            };
        }

        private Order MapToModel(OrderCreateDto OrderDto)
        {
            return new Order
            {
                CustomerId = OrderDto.CustomerId,
                OrderDate = OrderDto.OrderDate,
                TotalAmount = OrderDto.TotalAmount,
            };
        }
    }
}
