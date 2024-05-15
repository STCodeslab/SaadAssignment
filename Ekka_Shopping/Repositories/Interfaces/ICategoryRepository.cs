using Ekka_Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryById(int categoryId);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<bool> AddCategory(Category category);
        Task<bool> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int categoryId);
    }
}
