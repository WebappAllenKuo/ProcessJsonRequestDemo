using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
			string json = @"[
	{""Code"":200,""Orders"":[{""FruitName"":""xxx花東產西瓜xxx""}]},
			{ ""Code"":200,""Orders"":[{ ""3CName"":""蘋果""}]}
			]";

			return JsonConvert.DeserializeObject<UpStreamOrder[]>(json);
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
			UpStreamOrder[] orders = facade.GetOrder();
			return orders.Select(upOrder => new Order
			{
				Code = upOrder.Code, 
				Items = upOrder.Items.Select(upItem=>OrderItemFactory.GetObject(upItem)).ToArray()
			}).ToArray();
		}
	}

	public class OrderItemFactory
	{
		public static OrderItem GetObject(UpStreamOrderItem upItem)
		{
			if(!string.IsNullOrEmpty(upItem.FruitName))
				return new FruitOrderItem(upItem);
			else
			{
				return new TechProductOrderItem(upItem);
			}
		}
	}

	public class FruitOrderItem:OrderItem{
		public FruitOrderItem(UpStreamOrderItem upItem)
		{
			this.ProductName = upItem.FruitName;
		}
	}
	public class TechProductOrderItem:OrderItem
	{
		public TechProductOrderItem(UpStreamOrderItem upItem)
		{
			this.ProductName = upItem.TechProductName;
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
		public OrderItem[] Items { get; set; }
	}

	public class OrderItem
	{
		public string ProductName { get; set; }
	}
}
