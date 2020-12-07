using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp.UpStreamModels
{
	public class FacadeUpStreamTypedOrder
	{
		public UpStreamTypedOrder[] GetOrder()
		{
			string json = @"[
{""Code"":200,""Orders"":[{""FruitName"":""xxx花東產西瓜xxx""}]},
{ ""Code"":200,""Orders"":[{ ""3CName"":""蘋果""}]},
{ ""Code"":200,""Orders"":[{ ""3CName"":""橘子""}, { ""FoodName"":""肉圓""}]}
			]";

			return ParseOrders(json);
		}

		private UpStreamTypedOrder[] ParseOrders(string json)
		{
			var result = new List<UpStreamTypedOrder>();

			JArray sourceJson = JArray.Parse(json);

			foreach (var order in sourceJson)
			{
				var typedOrder = new UpStreamTypedOrder();
				typedOrder.Code = order.Value<int>("Code");

				var orderItemsArray = order.Value<JArray>("Orders"); //[0];
				typedOrder.Items = ParseOrderItems(orderItemsArray);

				result.Add(typedOrder);
			}

			return result.ToArray();
		}

		private UpStreamTypedOrderItem[] ParseOrderItems(JArray orderItesmArray)
		{
			var result = new List<UpStreamTypedOrderItem>();
			foreach (var orderItems in orderItesmArray)
			{
				foreach (var orderItem in orderItems.Value<JObject>())
				{
					var item = new UpStreamTypedOrderItem { TypeName = ParseTypeName(orderItem.Key), ProductName = orderItem.Value.ToString() };
					result.Add(item);
				}
				
			}

			return result.ToArray();
			// throw new NotImplementedException();
		}

		private string ParseTypeName(string orderItemKey)
		{
			string template = "Name";
			if (orderItemKey.EndsWith(template))
			{
				return orderItemKey.Substring(0, orderItemKey.Length - template.Length);
			}
			else
			{
				return orderItemKey;
			}
		}
	}
}