using Ekka_Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories.Interfaces
{
    public interface IGenderRepository
    {
        Task<Gender> GetGenderById(int genderId);
        Task<IEnumerable<Gender>> GetAllGenders();
        Task<bool> AddGender(Gender gender);
        Task<bool> UpdateGender(Gender gender);
        Task<bool> DeleteGender(Gender gender);
    }
}
