using erp_likom_data;
using erp_likom_model.Models;
using Microsoft.EntityFrameworkCore;

namespace erp_likom_repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly LikomDbContext _context;

        public ProductRepository(LikomDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            return await _context.Set<Product>()
                                 .FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            // Örnek bir kategori filtresi. Kategori ile ilgili bir alan ürün modelinde yoksa, bu metodu özelleştirin.
            return await _context.Set<Product>()
                                 .Where(p => p.Description.Contains(category)) // Burada kategoriyi tanımlamak için uygun filtreleme yapın
                                 .ToListAsync();
        }
    }

}
