using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
}
