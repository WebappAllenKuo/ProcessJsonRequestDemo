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

	public class TypedOrderService
	{
		private readonly ITypedOrderAdapter adapter;

		public TypedOrderService(ITypedOrderAdapter adapter)
		{
			this.adapter = adapter;
		}

		public TypedOrder[] ProcessOrders()
		{
			return adapter.GetOrders();
		}
	}
}