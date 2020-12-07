namespace ConsoleApp.Models
{
	public class OrderItem
	{
		public string ProductName { get; set; }
	}

	public class TypedOrderItem
	{
		public string TypeName { get; set; }
		public string ProductName { get; set; }
	}
}