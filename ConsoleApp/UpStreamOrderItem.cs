﻿using Newtonsoft.Json;

namespace ConsoleApp
{
	[JsonObject("UpStreamOrderItem")]
	public class UpStreamOrderItem
	{
		[JsonProperty("FruitName")]
		public string FruitName { get; set; }

		[JsonProperty("3CName")]
		public string TechProductName { get; set; }
	}
}