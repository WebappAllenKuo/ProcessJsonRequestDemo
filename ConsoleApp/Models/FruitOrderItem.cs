﻿using ConsoleApp.UpStreamModels;

namespace ConsoleApp.Models
{
	public class FruitOrderItem:OrderItem{
		public FruitOrderItem(UpStreamOrderItem upItem)
		{
			this.ProductName = upItem.FruitName;
		}
	}
}