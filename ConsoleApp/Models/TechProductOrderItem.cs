using ConsoleApp.UpStreamModels;

namespace ConsoleApp.Models
{
	public class TechProductOrderItem:OrderItem
	{
		public TechProductOrderItem(UpStreamOrderItem upItem)
		{
			this.ProductName = upItem.TechProductName;
		}
	}
}