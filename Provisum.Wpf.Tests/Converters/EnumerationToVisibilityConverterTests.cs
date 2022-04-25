using System.Collections.Generic;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provisum.Wpf.Converters;

namespace Provisum.Wpf.Tests.Converters
{
	[TestClass]
	public sealed class EnumerationToVisibilityConverterTests
	{
		private enum MockEnumeration
		{
			Foo, Bar, Baz
		}

		[TestMethod]
		public void TestConvertEqual()
		{
			var converter = new EnumerationToVisibilityConverter()
			{
				EqualVisibility = Visibility.Visible,
				NotEqualVisibility = Visibility.Collapsed,
				Value = MockEnumeration.Foo
			};

			Assert.AreEqual(Visibility.Visible, converter.Convert(MockEnumeration.Foo, null, null, null));
		}

		[TestMethod]
		public void TestConvertNotEqual()
		{
			var converter = new EnumerationToVisibilityConverter()
			{
				EqualVisibility = Visibility.Visible,
				NotEqualVisibility = Visibility.Collapsed,
				Value = MockEnumeration.Foo
			};

			Assert.AreEqual(Visibility.Collapsed, converter.Convert(MockEnumeration.Baz, null, null, null));
		}
	}
}
