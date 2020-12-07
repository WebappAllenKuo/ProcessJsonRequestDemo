namespace ConsoleApp.UpStreamModels
{
	public class UpStreamTypedOrder
	{
		public int Code { get; set; }

		public UpStreamTypedOrderItem[] Items { get; set; }
	}
}