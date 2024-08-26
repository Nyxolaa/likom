using erp_likom_model.DTOs;
using erp_likom_model.Models;
using erp_likom_repository.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace erp_likom_business
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            return MapToCustomerDto(customer);
        }

        public async Task<CustomerDto> GetCustomerByEmailAsync(string email)
        {
            var customer = await _unitOfWork.Customers.GetCustomerByEmailAsync(email);
            return MapToCustomerDto(customer);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            return customers.Select(MapToCustomerDto);
        }

        public async Task CreateCustomerAsync(CustomerDto CustomerDto)
        {
            var customer = MapToCustomer(CustomerDto);
            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateCustomerAsync(CustomerDto CustomerDto)
        {
            var customer = MapToCustomer(CustomerDto);
            await _unitOfWork.Customers.UpdateAsync(customer);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _unitOfWork.Customers.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        private CustomerDto MapToCustomerDto(Customer customer)
        {
            if (customer == null) return null;

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Address = customer.Address
                // Diğer alanları ekleyin
            };
        }

        private Customer MapToCustomer(CustomerDto CustomerDto)
        {
            if (CustomerDto == null) return null;

            return new Customer
            {
                Id = CustomerDto.Id,
                Name = CustomerDto.Name,
                Email = CustomerDto.Email,
                Address = CustomerDto.Address
                // Diğer alanları ekleyin
            };
        }
    }
}
