using erp_likom_data;
using Microsoft.EntityFrameworkCore;

namespace erp_likom_repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LikomDbContext _context;

        public IOrderRepository Orders { get; }
        public ICustomerRepository Customers { get; }
        public IProductRepository Products { get; }


        public UnitOfWork(LikomDbContext context, IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository products)
        {
            _context = context;
            Orders = orderRepository;
            Customers = customerRepository;
            Products = products;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }

}
