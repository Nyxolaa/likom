
namespace erp_likom_repository.Repositories
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        IOrderProductRepository OrderProducts { get; }
        Task<int> CompleteAsync();
    }
}
