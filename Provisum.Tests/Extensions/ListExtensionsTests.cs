using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provisum.Extensions;

namespace Provisum.Tests.Extensions
{
	[TestClass]
	public sealed class ListExtensionsTests
	{
		[TestMethod]
		public void TestSwap()
		{
			var array = new string[] { "Foo", "Bar", "Baz" };
			array.Swap(0, 2);

			Assert.IsTrue(array.SequenceEqual(new string[] { "Baz", "Bar", "Foo" }));
		}
	}
}
