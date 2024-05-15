// IOrdersRepository.cs
using Ekka_Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories.Interfaces
{
	public interface IOrdersRepository
	{
		Task<Order> GetOrderById(int orderId);
		Task<List<Order>> GetAllOrders();
		Task AddOrder(Order order);
		Task UpdateOrder(Order order);
		Task DeleteOrder(int orderId);
	}
}
