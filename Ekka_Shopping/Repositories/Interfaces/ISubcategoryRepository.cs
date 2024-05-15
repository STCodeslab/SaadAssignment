using Ekka_Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories.Interfaces
{
    public interface ISubcategoryRepository
    {
        Task<Subcategory> GetSubcategoryById(int subcategoryId);
        Task<IEnumerable<Subcategory>> GetAllSubcategories();
        Task<bool> AddSubcategory(Subcategory subcategory);
        Task<bool> UpdateSubcategory(Subcategory subcategory);
        Task<bool> DeleteSubcategory(int subcategoryId);
    }
}
