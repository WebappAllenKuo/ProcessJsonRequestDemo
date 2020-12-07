using ConsoleApp.Models;
using ConsoleApp.Services.OrderAdapters;

namespace ConsoleApp.Services
{
	public class OrderService
	{
		private readonly IOrderAdapter adapter;

		public OrderService(IOrderAdapter adapter)
		{
			this.adapter = adapter;
		}

		public Order[] ProcessOrders()
		{
			return adapter.GetOrders();
		}
	}
}