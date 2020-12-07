using ConsoleApp.Models;

namespace ConsoleApp.Services.OrderAdapters
{
	public interface IOrderAdapter
	{
		Order[] GetOrders();
	}
}