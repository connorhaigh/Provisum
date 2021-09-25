using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provisum.Utilities;

namespace Provisum.Tests.Utilities
{
	[TestClass]
	public sealed class NumberUtilitiesTests
	{
		[TestMethod]
		public void TestGetOrdinalFirst()
		{
			Assert.AreEqual("1st", NumberUtilities.GetOrdinal(1L));
		}

		[TestMethod]
		public void TestGetOrdinalSecond()
		{
			Assert.AreEqual("2nd", NumberUtilities.GetOrdinal(2L));
		}

		[TestMethod]
		public void TestGetOrdinalThird()
		{
			Assert.AreEqual("3rd", NumberUtilities.GetOrdinal(3L));
		}

		[TestMethod]
		public void TestGetOrdinalEleven()
		{
			Assert.AreEqual("11th", NumberUtilities.GetOrdinal(11L));
		}

		[TestMethod]
		public void TestGetOrdinalTwelve()
		{
			Assert.AreEqual("12th", NumberUtilities.GetOrdinal(12L));
		}

		[TestMethod]
		public void TestGetOrdinalThirteen()
		{
			Assert.AreEqual("13th", NumberUtilities.GetOrdinal(13L));
		}

		[TestMethod]
		public void TestGetOrdinalTwentyOne()
		{
			Assert.AreEqual("21st", NumberUtilities.GetOrdinal(21L));
		}

		[TestMethod]
		public void TestGetOrdinalTwentyTwo()
		{
			Assert.AreEqual("22nd", NumberUtilities.GetOrdinal(22L));
		}

		[TestMethod]
		public void TestGetOrdinalTwentyThree()
		{
			Assert.AreEqual("23rd", NumberUtilities.GetOrdinal(23L));
		}
	}
}
