using erp_likom_model.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace erp_likom_business
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> GetProductByNameAsync(string name);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category);
        Task CreateProductAsync(ProductCreateDto ProductDto);
        Task UpdateProductAsync(ProductDto ProductDto);
        Task DeleteProductAsync(int id);
    }
}
