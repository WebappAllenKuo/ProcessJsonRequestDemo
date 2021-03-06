﻿using Newtonsoft.Json;

namespace ConsoleApp.UpStreamModels
{
	public class UpStreamOrder
	{
		public int Code { get; set; }

		[JsonProperty("Orders")]
		public UpStreamOrderItem[] Items { get; set; }
	}
}