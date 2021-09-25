using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provisum.Utilities;

namespace Provisum.Tests.Utilities
{
	[TestClass]
	public sealed class DateTimeUtilitiesTests
	{
		[TestMethod]
		public void TestGetTimeAgoNow()
		{
			Assert.AreEqual("Now", DateTimeUtilities.GetTimeAgo(0));
		}

		[TestMethod]
		public void TestGetTimeAgoOneMinute()
		{
			Assert.AreEqual("1 minutes ago", DateTimeUtilities.GetTimeAgo(60));
		}

		[TestMethod]
		public void TestGetTimeAgoOneHour()
		{
			Assert.AreEqual("1 hours ago", DateTimeUtilities.GetTimeAgo(3600));
		}

		[TestMethod]
		public void TestGetTimeAgoOneDay()
		{
			Assert.AreEqual("1 days ago", DateTimeUtilities.GetTimeAgo(86400));
		}

		[TestMethod]
		public void TestGetTimeAgoOneWeek()
		{
			Assert.AreEqual("1 weeks ago", DateTimeUtilities.GetTimeAgo(604800));
		}

		[TestMethod]
		public void TestGetTimeAgoOneMonth()
		{
			Assert.AreEqual("1 months ago", DateTimeUtilities.GetTimeAgo(2592000));
		}

		[TestMethod]
		public void TestGetTimeAgoOneYear()
		{
			Assert.AreEqual("1 years ago", DateTimeUtilities.GetTimeAgo(31622400));
		}
	}
}
