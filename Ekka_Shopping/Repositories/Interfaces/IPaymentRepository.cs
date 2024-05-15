// IPaymentRepository.cs
using Ekka_Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories.Interfaces
{
	public interface IPaymentRepository
	{
		Task<Payment> GetPaymentById(int paymentId);
		Task<List<Payment>> GetAllPayments();
		Task AddPayment(Payment payment);
		Task UpdatePayment(Payment payment);
		Task DeletePayment(int paymentId);
	}
}
