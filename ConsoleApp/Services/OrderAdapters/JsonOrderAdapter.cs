using System.Linq;
using ConsoleApp.Models;
using ConsoleApp.Services.OrderAdapters;
using ConsoleApp.UpStreamModels;

namespace ConsoleApp.Services.OrderAdapters
{
	public class JsonOrderAdapter : IOrderAdapter
	{
		private FacadeUpStreamOrder facade;

		public JsonOrderAdapter(FacadeUpStreamOrder facade)
		{
			this.facade = facade;
		}
		public Order[] GetOrders()
		{
			UpStreamOrder[] orders = facade.GetOrder();
			return orders.Select(upOrder => new Order
			{
				Code = upOrder.Code, 
				Items = upOrder.Items.Select(upItem=>OrderItemFactory.GetObject(upItem)).ToArray()
			}).ToArray();
		}
	}

	public class JsonTypedOrderAdapter : ITypedOrderAdapter
	{
		private FacadeUpStreamTypedOrder facade;

		public JsonTypedOrderAdapter(FacadeUpStreamTypedOrder facade)
		{
			this.facade = facade;
		}
		public TypedOrder[] GetOrders()
		{
			UpStreamTypedOrder[] orders = facade.GetOrder();
			return orders.Select(upOrder => new TypedOrder
			{
				Code = upOrder.Code,
				Items = upOrder.Items.Select(upItem => new TypedOrderItem{TypeName = upItem.TypeName, ProductName = upItem.ProductName}).ToArray()
			}).ToArray();
		}
	}
}