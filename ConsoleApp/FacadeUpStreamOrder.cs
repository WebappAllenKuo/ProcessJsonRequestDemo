using ConsoleApp.UpStreamModels;
using Newtonsoft.Json;

namespace ConsoleApp
{
	public class FacadeUpStreamOrder
	{
		public UpStreamOrder[] GetOrder()
		{
			string json = @"[
	{""Code"":200,""Orders"":[{""FruitName"":""xxx花東產西瓜xxx""}]},
			{ ""Code"":200,""Orders"":[{ ""3CName"":""蘋果""}]}
			]";

			return JsonConvert.DeserializeObject<UpStreamOrder[]>(json);
		}
	}
}