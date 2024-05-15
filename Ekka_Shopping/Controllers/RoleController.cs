using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ekka_Shopping.Models;
using Ekka_Shopping.Repositories;
using Ekka_Shopping.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Ekka_Shopping.Controllers
{
    [Authorize(Roles = "1")]

    public class RoleController : Controller
	{

		private readonly IRoleRepository _roleRepository;

		public RoleController(IRoleRepository roleRepository)
		{
			_roleRepository = roleRepository;
		}

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> AddRole(Role role)
		{
			bool result = await _roleRepository.AddRole(role);
			if (result)
			{
				TempData["Role_Insert_Success"] = "Role Added Successfully!";
			}
			else
			{
				TempData["Role_Insert_Error"] = "Role with the same name already exists!";
			}
			return RedirectToAction(nameof(Role_Show));
		}


		public async Task<IActionResult> DeleteRole(int id)
		{
			var role = await _roleRepository.GetRoleById(id);
			if (role == null)
			{
				NotFound();
			}

			return View(role);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteRole(Role role)
		{
			bool deleted = await _roleRepository.DeleteRole(role);
			if (deleted)
			{
				TempData["Role_Delete_Success"] = "Role deleted successfully!";
			}
			else
			{
				TempData["Role_Delete_Error"] = "Role not found or error deleting role!";
			}
			return RedirectToAction(nameof(Role_Show));
		}

		public async Task<IActionResult> Role_Show()
		{
			var roles = await _roleRepository.GetAllRoles();
			return View(roles);
		}


		public async Task<IActionResult> UpdateRole(int id)
		{

            {
                var role = await _roleRepository.GetRoleById(id);
                if (role == null)
                {
                    return NotFound(); 
                }
                return View(role); 
            }
        }

		[HttpPost]
		public async Task<IActionResult> UpdateRole(Role role)
		{
			bool updated = await _roleRepository.UpdateRole(role);
			if (updated)
			{
				TempData["UpdateRoleMessage"] = "Role updated successfully!";
			}
			else
			{
				TempData["UpdateRoleMessage"] = "Role not found or error updating role!";
			}
			return RedirectToAction(nameof(Role_Show));
		}

		public async Task<IActionResult> GetRoleById(int roleId)
		{
			try
			{
				var role = await _roleRepository.GetRoleById(roleId);
				if (role != null)
				{
					return View(role);
				}
				else
				{
					TempData["GetRoleByIdMessage"] = "Role not found!";
					return RedirectToAction(nameof(Role_Show));
				}
			}
			catch (Exception ex)
			{
				// Log the exception or handle it as needed
				TempData["GetRoleByIdMessage"] = "Error fetching role: " + ex.Message;
				return RedirectToAction(nameof(Role_Show));
			}
		}
	}
}
