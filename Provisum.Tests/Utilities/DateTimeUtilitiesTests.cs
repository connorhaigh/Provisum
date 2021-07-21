using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provisum.Utilities;

namespace Provisum.Tests.Utilities
{
	[TestClass]
	public sealed class DateTimeUtilitiesTests
	{
		[TestMethod]
		public void TestNow()
		{
			Assert.AreEqual(DateTimeUtilities.GetTimeAgo(0), "Now");
		}

		[TestMethod]
		public void TestOneMinuteAgo()
		{
			Assert.AreEqual(DateTimeUtilities.GetTimeAgo(60), "1 minutes ago");
		}

		[TestMethod]
		public void TestOneHourAgo()
		{
			Assert.AreEqual(DateTimeUtilities.GetTimeAgo(3600), "1 hours ago");
		}

		[TestMethod]
		public void TestOneDayAgo()
		{
			Assert.AreEqual(DateTimeUtilities.GetTimeAgo(86400), "1 days ago");
		}

		[TestMethod]
		public void TestOneWeekAgo()
		{
			Assert.AreEqual(DateTimeUtilities.GetTimeAgo(604800), "1 weeks ago");
		}

		[TestMethod]
		public void TestOneMonthAgo()
		{
			Assert.AreEqual(DateTimeUtilities.GetTimeAgo(2592000), "1 months ago");
		}

		[TestMethod]
		public void TestOneYearAgo()
		{
			Assert.AreEqual(DateTimeUtilities.GetTimeAgo(31622400), "1 years ago");
		}
	}
}
