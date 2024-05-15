using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ekka_Shopping.Models
{
	public class Invoice
	{
		[Key]
		public int Invoice_Id { get; set; }

		public int? Order_Id { get; set; }

		public int? Product_Id { get; set; }

		public int? Quantity { get; set; }

		public int OrderId { get; set; }

		[ForeignKey("OrderId")]

		public virtual Order? Order { get; set; }

		public int ProductId { get; set; }

		[ForeignKey("ProductId")]

		public virtual Product? Product { get; set; }




	}
}
