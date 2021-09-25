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

			Assert.AreEqual(Visibility.Visible, converter.Convert(true, null, null, null));
		}

		[TestMethod]
		public void TestConvertFalse()
		{
			var converter = new BoolToVisibilityConverter()
			{
				TrueVisibility = Visibility.Visible,
				FalseVisibility = Visibility.Collapsed
			};

			Assert.AreEqual(Visibility.Collapsed, converter.Convert(false, null, null, null));
		}
	}
}
