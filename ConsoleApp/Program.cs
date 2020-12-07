using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Models;
using ConsoleApp.Services;
using ConsoleApp.Services.OrderAdapters;
using ConsoleApp.UpStreamModels;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			// FacadeUpStreamOrder facade = new FacadeUpStreamOrder();

			// IOrderAdapter adapter = new JsonOrderAdapter(facade);

			// Order[] orders = new OrderService(adapter).ProcessOrders();

			var facade = new FacadeUpStreamTypedOrder();
			
			ITypedOrderAdapter adapter = new JsonTypedOrderAdapter(facade);

			TypedOrder[] orders = new TypedOrderService(adapter).ProcessOrders();
		}
	}
}
