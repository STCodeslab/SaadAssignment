using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ekka_Shopping.Models
{
	public class Product
	{
		[Key]
		public int Pro_Id { get; set; }

		[Required]
		public string? Pro_Name { get; set; }

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal Pro_Price { get; set; }

		[Required]
		public string? Pro_Description { get; set; }

		[Required]
		public string? Pro_Image { get; set; }

		public int? Subcategory_id { get; set; }

		[ForeignKey("Subcategory_id")]
		public virtual Subcategory? Subcategory { get; set; }

		public virtual ICollection<Invoice>? Invoices { get; set; }
	}
}
