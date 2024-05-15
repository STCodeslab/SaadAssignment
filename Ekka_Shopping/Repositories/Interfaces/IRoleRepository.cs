
using Ekka_Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories.Interfaces
{
	public interface IRoleRepository
	{
		Task<Role> GetRoleById(int roleId);
		Task<IEnumerable<Role>> GetAllRoles();
		Task<bool> AddRole(Role role);
		Task<bool> UpdateRole(Role role);
		Task<bool> DeleteRole(Role role);
	}
}
