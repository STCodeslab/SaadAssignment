using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ekka_Shopping.Models
{
	public class Role
	{

		[Key]
        public int RoleId { get; set; }

		[Required]
	    public string? RoleName { get; set; }

		public ICollection<User>? Users { get; set; }


	}
}
