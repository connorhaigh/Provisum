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

			Assert.AreEqual(converter.Convert("Foo", null, null, null), Visibility.Visible);
		}

		[TestMethod]
		public void TestConvertNull()
		{
			var converter = new NullToVisibilityConverter()
			{
				NotNullVisibility = Visibility.Visible,
				NullVisibility = Visibility.Collapsed
			};

			Assert.AreEqual(converter.Convert(null, null, null, null), Visibility.Collapsed);
		}
	}
}
