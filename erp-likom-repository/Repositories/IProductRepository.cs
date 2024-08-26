using erp_likom_model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_likom_repository.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductByNameAsync(string name);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
    }

}
