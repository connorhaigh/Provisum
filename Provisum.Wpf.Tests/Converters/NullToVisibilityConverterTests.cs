using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provisum.Wpf.Converters;

namespace Provisum.Wpf.Tests.Converters
{
	[TestClass]
	public sealed class NullToVisibilityConverterTests
	{
		[TestMethod]
		public void TestConvertNotNull()
		{
			var converter = new NullToVisibilityConverter()
			{
				NotNullVisibility = Visibility.Visible,
				NullVisibility = Visibility.Collapsed
			};

			Assert.AreEqual(Visibility.Visible, converter.Convert("Value", null, null, null));
		}

		[TestMethod]
		public void TestConvertNull()
		{
			var converter = new NullToVisibilityConverter()
			{
				NotNullVisibility = Visibility.Visible,
				NullVisibility = Visibility.Collapsed
			};

			Assert.AreEqual(Visibility.Collapsed, converter.Convert(null, null, null, null));
		}
	}
}
