using System.Linq;

namespace ConsoleApp
{
	internal class JsonOrderAdapter : IOrderAdapter
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
}