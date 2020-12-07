namespace ConsoleApp.Models
{
	public class Order
	{
		public int Code;
		public OrderItem[] Items { get; set; }
	}
}