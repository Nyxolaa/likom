using erp_likom_model.DTOs;
using erp_likom_model.Models;
using erp_likom_repository.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erp_likom_business.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private OrderProductDto ToDTO(OrderProduct orderProduct) => new OrderProductDto
        {
            Id = orderProduct.Id,
            OrderId = orderProduct.OrderId,
            ProductId = orderProduct.ProductId,
            Quantity = orderProduct.Quantity
        };

        private OrderProduct ToDomainModel(OrderProductDto orderProductDto) => new OrderProduct
        {
            Id = orderProductDto.Id,
            OrderId = orderProductDto.OrderId,
            ProductId = orderProductDto.ProductId,
            Quantity = orderProductDto.Quantity           
        };

        public async Task<OrderProductDto> GetOrderProductByIdAsync(int id)
        {
            var orderProduct = await _unitOfWork.OrderProducts.GetByIdAsync(id);
            return orderProduct == null ? null : ToDTO(orderProduct);
        }

        public async Task<IEnumerable<OrderProductDto>> GetOrderProductsByOrderIdAsync(int orderId)
        {
            var orderProducts = await _unitOfWork.OrderProducts.GetByOrderIdAsync(orderId);
            return orderProducts.Select(ToDTO);
        }

        public async Task CreateOrderProductAsync(OrderProductDto orderProductDto)
        {
            var orderProduct = ToDomainModel(orderProductDto);
            await _unitOfWork.OrderProducts.AddAsync(orderProduct);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateOrderProductAsync(OrderProductDto orderProductDto)
        {
            var orderProduct = ToDomainModel(orderProductDto);
            await _unitOfWork.OrderProducts.UpdateAsync(orderProduct);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteOrderProductAsync(int id)
        {
            await _unitOfWork.OrderProducts.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<IEnumerable<OrderProductDto>> GetAllAsync()
        {
            var orderProducts = await _unitOfWork.OrderProducts.GetAllAsync();
            return orderProducts.Select(ToDTO);
        }
    }
}
