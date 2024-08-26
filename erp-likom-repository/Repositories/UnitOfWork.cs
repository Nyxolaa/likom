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
        public IOrderProductRepository OrderProducts { get; }

        public UnitOfWork(LikomDbContext context, IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository products, IOrderProductRepository orderProducts)
        {
            _context = context;
            Orders = orderRepository;
            Customers = customerRepository;
            Products = products;
            OrderProducts = orderProducts;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }

}
