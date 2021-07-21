using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provisum.Utilities;

namespace Provisum.Tests.Utilities
{
	[TestClass]
	public sealed class FileUtilitiesTests
	{
		[TestMethod]
		public void TestZeroBytes()
		{
			Assert.AreEqual("0 bytes", FileUtilities.GetSize(0));
		}

		[TestMethod]
		public void TestOneKilobyte()
		{
			Assert.AreEqual("1 KB", FileUtilities.GetSize(1024));
		}

		[TestMethod]
		public void TestOneMegabyte()
		{
			Assert.AreEqual("1 MB", FileUtilities.GetSize(1048576));
		}

		[TestMethod]
		public void TestOneGigabyte()
		{
			Assert.AreEqual("1 GB", FileUtilities.GetSize(1073741824));
		}

		[TestMethod]
		public void TestOneTerabyte()
		{
			Assert.AreEqual("1 TB", FileUtilities.GetSize(1099511627776));
		}
	}
}
