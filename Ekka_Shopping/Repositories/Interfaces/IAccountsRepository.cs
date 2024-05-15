using Ekka_Shopping.Models;

namespace Ekka_Shopping.Repositories.Interfaces
{
    public interface IAccountsRepository
    {

        Task<bool> SignUpAsync(User data);

        Task<User> GetUserByEmail(string email);


       Task<User> GetUserForLoginAsync(string email, string password);
    }
}
