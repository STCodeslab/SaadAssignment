using Ekka_Shopping.Data;
using Ekka_Shopping.Models;
using Ekka_Shopping.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Ekka_Shopping.Repositories
{
	public class RoleRepository : IRoleRepository
	{
		private readonly EkkaContext db;
        public RoleRepository(EkkaContext db)
        {
			this.db = db;
            
        }
		public async Task<bool> AddRole(Role role)
		{
			try
			{
				if (await db.Roles.AnyAsync(r => r.RoleName == role.RoleName))
				{
					return false; // Role with the same name already exists
				}
				else
				{
					await db.Roles.AddAsync(role);
					await db.SaveChangesAsync();
					return true; // Role Added Successfully
				}
			}
			catch (DbUpdateException)
			{
				// This exception can occur if there's a problem with saving changes to the database
				return false; // Error Adding Role
			}
			catch (Exception)
			{
				// Handle other unexpected exceptions
				return false; // Unexpected Error Adding Role
			}
		}

        public async Task<bool> DeleteRole(Role role)
        {
            try
            {
                var existingRole = await db.Roles.FindAsync(role.RoleId);
                if (existingRole != null)
                {
                    // Check if any user is associated with this role
                    var usersWithRole = await db.Users.Where(u => u.RoleId == role.RoleId).ToListAsync();

                    if (usersWithRole.Count > 0)
                    {
                        return false; // Users exist with this role, don't delete
                    }

                    db.Roles.Remove(existingRole);
                    await db.SaveChangesAsync();
                    return true; // Success
                }
                else
                {
                    return false; // Role not found
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false; // Error
            }
        }


        public async Task<IEnumerable<Role>> GetAllRoles()
		{
			return await db.Roles.ToListAsync();
		}

		public async Task<bool> UpdateRole(Role role)
		{
			try
			{
				var existingRole = await db.Roles.FindAsync(role.RoleId);
				if (existingRole != null)
				{
					existingRole.RoleName = role.RoleName;
					await db.SaveChangesAsync();
					return true; // Success
				}
				else
				{
					return false; // Role not found
				}
			}
			catch (Exception ex)
			{
				// Log the exception or handle it as needed
				return false; // Error
			}
		}

		public async Task<Role> GetRoleById(int roleId)
		{
			try
			{
				return await db.Roles.FindAsync(roleId);
			}
			catch (Exception ex)
			{
				// Log the exception or handle it as needed
				throw new Exception("Error fetching role by ID: " + ex.Message);
			}
		}


	}
}
