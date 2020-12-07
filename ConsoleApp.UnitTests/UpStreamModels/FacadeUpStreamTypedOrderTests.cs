using ConsoleApp.UpStreamModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.UnitTests.UpStreamModels
{
	class FacadeUpStreamTypedOrderTests
	{
		[Test]
		public void GetOrder_WhenCalled() {
			var sut = new FacadeUpStreamTypedOrder();

			var actual = sut.GetOrder();

		}
	}
}
