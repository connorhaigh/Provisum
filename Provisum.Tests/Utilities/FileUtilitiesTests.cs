using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provisum.Utilities;

namespace Provisum.Tests.Utilities
{
	[TestClass]
	public sealed class FileUtilitiesTests
	{
		[TestMethod]
		public void TestGetSizeZeroBytes()
		{
			Assert.AreEqual("0 bytes", FileUtilities.GetSize(0));
		}

		[TestMethod]
		public void TestGetSizeOneKilobyte()
		{
			Assert.AreEqual("1 KB", FileUtilities.GetSize(1024));
		}

		[TestMethod]
		public void TestGetSizeOneMegabyte()
		{
			Assert.AreEqual("1 MB", FileUtilities.GetSize(1048576));
		}

		[TestMethod]
		public void TestGetSizeOneGigabyte()
		{
			Assert.AreEqual("1 GB", FileUtilities.GetSize(1073741824));
		}

		[TestMethod]
		public void TestGetSizeOneTerabyte()
		{
			Assert.AreEqual("1 TB", FileUtilities.GetSize(1099511627776));
		}
	}
}
