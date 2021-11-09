using System.Collections.Generic;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provisum.Wpf.Converters;

namespace Provisum.Wpf.Tests.Converters
{
	[TestClass]
	public sealed class EnumerableToVisibilityConverterTests
	{
		[TestMethod]
		public void TestConvertNotEmpty()
		{
			var converter = new EnumerableToVisibilityConverter()
			{
				NotEmptyVisibility = Visibility.Visible,
				EmptyVisibility = Visibility.Collapsed,
			};

			var list = new List<string>()
			{
				"Alpha",
				"Bravo",
				"Charlie"
			};

			Assert.AreEqual(Visibility.Visible, converter.Convert(list, null, null, null));
		}

		[TestMethod]
		public void TestConvertNotEmptyCount()
		{
			var converter = new EnumerableToVisibilityConverter()
			{
				NotEmptyVisibility = Visibility.Visible,
				EmptyVisibility = Visibility.Collapsed,
				Count = 3
			};

			var notEmptyList = new List<string>()
			{
				"Alpha",
				"Bravo",
				"Charlie",
				"Delta"
			};

			var emptyList = new List<string>()
			{
				"Alpha",
				"Bravo",
				"Charlie",
			};

			Assert.AreEqual(Visibility.Visible, converter.Convert(notEmptyList, null, null, null));
			Assert.AreEqual(Visibility.Collapsed, converter.Convert(emptyList, null, null, null));
		}

		[TestMethod]
		public void TestConvertEmpty()
		{
			var converter = new EnumerableToVisibilityConverter()
			{
				NotEmptyVisibility = Visibility.Visible,
				EmptyVisibility = Visibility.Collapsed
			};

			var list = new List<string>();

			Assert.AreEqual(Visibility.Collapsed, converter.Convert(list, null, null, null));
		}
	}
}
