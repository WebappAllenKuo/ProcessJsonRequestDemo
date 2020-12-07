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
			Order[] orders = OrderService.ProcessOrders();
		}
	}

	public class OrderService
	{
		public static Order[] ProcessOrders()
		{
			throw new NotImplementedException();
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
