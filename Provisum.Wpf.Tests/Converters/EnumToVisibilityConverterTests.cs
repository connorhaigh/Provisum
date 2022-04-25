using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provisum.Wpf.Converters;

namespace Provisum.Wpf.Tests.Converters
{
	[TestClass]
	public sealed class EnumVisibilityConverterTests
	{
		private enum MockEnum
		{
			Foo, Bar, Baz
		}

		[TestMethod]
		public void TestConvertEqual()
		{
			var converter = new EnumToVisibilityConverter()
			{
				EqualVisibility = Visibility.Visible,
				NotEqualVisibility = Visibility.Collapsed,
				Value = MockEnum.Foo
			};

			Assert.AreEqual(Visibility.Visible, converter.Convert(MockEnum.Foo, null, null, null));
		}

		[TestMethod]
		public void TestConvertNotEqual()
		{
			var converter = new EnumToVisibilityConverter()
			{
				EqualVisibility = Visibility.Visible,
				NotEqualVisibility = Visibility.Collapsed,
				Value = MockEnum.Foo
			};

			Assert.AreEqual(Visibility.Collapsed, converter.Convert(MockEnum.Baz, null, null, null));
		}

		[TestMethod]
		public void TestConvertNull()
		{
			var converter = new EnumToVisibilityConverter()
			{
				NotEqualVisibility = Visibility.Collapsed,
			};

			Assert.AreEqual(Visibility.Collapsed, converter.Convert(null, null, null, null));
		}
	}
}
