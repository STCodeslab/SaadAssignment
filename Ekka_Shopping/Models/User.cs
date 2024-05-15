using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ekka_Shopping.Models;


namespace Ekka_Shopping.Models
{
	public class User
	{
		[Key]
        public int UserId { get; set; }

		[Required]
		public string? UserFullName { get; set; }

		[Required]
		public string? UserEmail { get; set;}


		[Required]
		public string? UserPassword { get; set;}

		public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }

		public virtual ICollection<Order>? Orders { get; set; }



	}
}
