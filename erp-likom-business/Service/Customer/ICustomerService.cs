using erp_likom_model.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace erp_likom_business
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task<CustomerDto> GetCustomerByEmailAsync(string email);
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task CreateCustomerAsync(CustomerDto CustomerDto);
        Task UpdateCustomerAsync(CustomerDto CustomerDto);
        Task DeleteCustomerAsync(int id);
    }
}
