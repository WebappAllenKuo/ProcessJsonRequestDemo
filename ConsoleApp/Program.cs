using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			FacadeUpStreamOrder facade = new FacadeUpStreamOrder();

			IOrderAdapter adapter = new JsonOrderAdapter(facade);

			Order[] orders = new OrderService(adapter).ProcessOrders();
		}
	}

	public class FacadeUpStreamOrder
	{
		public UpStreamOrder[] GetOrder()
		{
			throw new NotImplementedException();
		}
	}

	internal class JsonOrderAdapter : IOrderAdapter
	{
		private FacadeUpStreamOrder facade;

		public JsonOrderAdapter(FacadeUpStreamOrder facade)
		{
			this.facade = facade;
		}
		public Order[] GetOrders()
		{
			// UpStreamOrder[] orders = facade.GetOrder();
			throw new NotImplementedException();
		}
	}

	public class UpStreamOrder
	{
		public int Code { get; set; }

		[JsonProperty("Orders")]
		public UpStreamOrderItem[] Items { get; set; }
	}

	[JsonObject("UpStreamOrderItem")]
	public class UpStreamOrderItem
	{
		[JsonProperty("FruitName")]
		public string FruitName { get; set; }

		[JsonProperty("3CName")]
		public string TechProductName { get; set; }
	}

	public interface IOrderAdapter
	{
		Order[] GetOrders();
	}

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

	public class Order
	{
		public int Code;
		public OrderItems[] Items { get; set; }
	}

	public class OrderItems
	{
		public string ProductName { get; set; }
	}
}
