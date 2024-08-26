using erp_likom_data;
using erp_likom_model.Models;
using Microsoft.EntityFrameworkCore;

namespace erp_likom_repository.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly LikomDbContext _context;

        public CustomerRepository(LikomDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _context.Set<Customer>()
                                 .FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
