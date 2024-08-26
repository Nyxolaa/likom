using erp_likom_model.DTOs;
using erp_likom_model.Models;
using erp_likom_repository.Repositories;

namespace erp_likom_business.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private ProductDto ToDTO(Product product) => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity
        };

        private Product ToDomainModel(ProductDto ProductDto) => new Product
        {
            Id = ProductDto.Id,
            Name = ProductDto.Name,
            Description = ProductDto.Description,
            Price = ProductDto.Price,
            StockQuantity = ProductDto.StockQuantity
        };

        private Product ToDomainModel(ProductCreateDto ProductDto) => new Product
        {
            Name = ProductDto.Name,
            Description = ProductDto.Description,
            Price = ProductDto.Price,
            StockQuantity = ProductDto.StockQuantity
        };

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            return product == null ? null : ToDTO(product);
        }

        public async Task<ProductDto> GetProductByNameAsync(string name)
        {
            var product = await _unitOfWork.Products.GetProductByNameAsync(name);
            return product == null ? null : ToDTO(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category)
        {
            var products = await _unitOfWork.Products.GetProductsByCategoryAsync(category);
            return products.Select(ToDTO);
        }

        public async Task CreateProductAsync(ProductCreateDto ProductDto)
        {
            var product = ToDomainModel(ProductDto);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateProductAsync(ProductDto ProductDto)
        {
            var product = ToDomainModel(ProductDto);
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            await _unitOfWork.Products.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
