using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ekka_Shopping.Models
{
	public class Order
	{
		[Key]
		public int Order_Id { get; set; }

		public int? Order_Amount { get; set; }

		public int? UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User? User { get; set; }

		public ICollection<Invoice>? Invoices { get; set; }

		public virtual ICollection<Payment>? Payments { get; set; }


	}
}
