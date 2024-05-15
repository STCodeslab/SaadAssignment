using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ekka_Shopping.Models
{
	public class Category
	{
		[Key]
		public int Category_Id { get; set; }

		[Required]
		public string? Category_Name { get; set; }

		public int? Gender_id { get; set; }

		[ForeignKey("Gender_id")]
		public virtual Gender? Gender { get; set; }

        public ICollection<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    }
}
