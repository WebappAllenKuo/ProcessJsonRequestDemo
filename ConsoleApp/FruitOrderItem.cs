using ConsoleApp.UpStreamModels;

namespace ConsoleApp
{
	public class FruitOrderItem:OrderItem{
		public FruitOrderItem(UpStreamOrderItem upItem)
		{
			this.ProductName = upItem.FruitName;
		}
	}
}