namespace ConsoleApp
{
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
}