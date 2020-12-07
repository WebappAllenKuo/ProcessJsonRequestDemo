namespace ConsoleApp
{
	public class TechProductOrderItem:OrderItem
	{
		public TechProductOrderItem(UpStreamOrderItem upItem)
		{
			this.ProductName = upItem.TechProductName;
		}
	}
}