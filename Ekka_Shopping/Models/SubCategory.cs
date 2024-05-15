using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ekka_Shopping.Models
{
	public class Subcategory
	{
		[Key]
		public int subcategory_id { get; set; }

		[Required]
		public string? subcategory_name { get; set; }

		public int? category_id { get; set; }

		[ForeignKey("category_id")]
		public virtual Category? Category { get; set; }


        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
