// IInvoiceRepository.cs
using Ekka_Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories.Interfaces
{
	public interface IInvoiceRepository
	{
		Task<Invoice> GetInvoiceById(int invoiceId);
		Task<List<Invoice>> GetAllInvoices();
		Task AddInvoice(Invoice invoice);
		Task UpdateInvoice(Invoice invoice);
		Task DeleteInvoice(int invoiceId);
	}
}
