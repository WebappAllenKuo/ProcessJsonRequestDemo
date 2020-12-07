namespace ConsoleApp.Models
{
	public class Order
	{
		public int Code;
		public OrderItem[] Items { get; set; }
	}

	public class TypedOrder
	{
		public int Code;
		public TypedOrderItem[] Items { get; set; }
	}
}