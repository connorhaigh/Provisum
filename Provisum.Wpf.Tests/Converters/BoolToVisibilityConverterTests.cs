using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provisum.Wpf.Converters;

namespace Provisum.Wpf.Tests.Converters
{
	[TestClass]
	public sealed class BoolToVisibilityConverterTests
	{
		[TestMethod]
		public void TestConvertTrue()
		{
			var converter = new BoolToVisibilityConverter()
			{
				TrueVisibility = Visibility.Visible,
				FalseVisibility = Visibility.Collapsed
			};

			Assert.AreEqual(converter.Convert(true, null, null, null), Visibility.Visible);
		}

		[TestMethod]
		public void TestConvertFalse()
		{
			var converter = new BoolToVisibilityConverter()
			{
				TrueVisibility = Visibility.Visible,
				FalseVisibility = Visibility.Collapsed
			};

			Assert.AreEqual(converter.Convert(false, null, null, null), Visibility.Collapsed);
		}
	}
}
