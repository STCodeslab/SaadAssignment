using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ekka_Shopping.Models
{
	public class Payment
	{
		[Key]
		public int PaymentId { get; set; }

		public int? OrderId { get; set; }

		[Required]
		public int Amount { get; set; }

		[Required]
		public DateTime PaymentDate { get; set; }

		[ForeignKey("OrderId")]
		public virtual Order? Order { get; set; }
	}
}
