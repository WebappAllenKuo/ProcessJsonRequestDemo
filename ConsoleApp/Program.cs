using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			IOrderAdapter adapter = new JsonOrderAdapter();

			Order[] orders = new OrderService(adapter).ProcessOrders();
		}
	}

	internal class JsonOrderAdapter : IOrderAdapter
	{
		public Order[] GetOrders()
		{
			throw new NotImplementedException();
		}
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
