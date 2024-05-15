using System.ComponentModel.DataAnnotations;

namespace Ekka_Shopping.Models
{
	public class Gender
	{
		[Key]
		public int gender_id { get; set; }

		[Required]
		public string? gender_name { get; set; }

		public ICollection<Category>? Categories { get; set; }
	}
}
