using Ekka_Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int productId);
        Task<IEnumerable<Product>> GetAllProducts();
      
        Task<bool> DeleteProduct(int productId);

        Task<bool> AddingProducts(Product product, IFormFile Pro_Image);

        Task<bool> UpdatingProducts(Product product, IFormFile Pro_Image);

        IEnumerable<Product> GetProductsByGender(int genderId);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        IEnumerable<Product> GetProductsBySubcategory(int subcategoryId);

        Product GetProductsById(int productId);
    }
}
