// IUserRepository.cs
using Ekka_Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories.Interfaces
{
	public interface IUsersRepository
	{
		Task<User> GetUserById(int userId);
		Task<List<User>> GetAllUsers();
		Task AddUser(User user);
		Task UpdateUser(User user);
		Task DeleteUser(int userId);
	}
}
