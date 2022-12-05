using Dotnet7_API.Models;

namespace Dotnet7_API.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task<List<Product>> AddProduct(Product product);
        Task<List<Product>?> UpdateProduct(int id, Product request);
        Task<List<Product>?> DeleteProductById(int id);
    }
}
