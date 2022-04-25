using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Provisum.Wpf.Converters
{
	/// <summary>
	/// Represents an <see cref="IEnumerable" /> to <see cref="Visibility" /> converter.
	/// Returns a specific visibility when the value has either a certain number of elements, or is empty.
	/// </summary>
	public sealed class EnumerableToVisibilityConverter : DependencyObject, IValueConverter
	{
		/// <inheritdoc />
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return this.EmptyVisibility;
			}

			if (value is IEnumerable enumerableValue)
			{
				var count = 0;
				var enumerator = enumerableValue.GetEnumerator();

				while (enumerator.MoveNext())
				{
					count++;

					if (count > this.Count)
					{
						return this.NotEmptyVisibility;

					}
				}

				return this.EmptyVisibility;
			}

			throw new ArgumentException("Value is not an enumerable.", nameof(value));
		}

		/// <inheritdoc />
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

		/// <summary>
		/// Represents the property for the visibility for when the value is not empty.
		/// </summary>
		public static readonly DependencyProperty NotEmptyVisibilityProperty =
			DependencyProperty.Register("NotEmptyVisibility", typeof(Visibility), typeof(EnumerableToVisibilityConverter), new PropertyMetadata(Visibility.Visible));

		/// <summary>
		/// Represents the property for the visibility for when the value is empty.
		/// </summary>
		public static readonly DependencyProperty EmptyVisibilityProperty =
			DependencyProperty.Register("EmptyVisibility", typeof(Visibility), typeof(EnumerableToVisibilityConverter), new PropertyMetadata(Visibility.Collapsed));

		/// <summary>
		/// Represents the property for the threshold when to consider an enumerable to be empty.
		/// </summary>
		public static readonly DependencyProperty CountProperty =
			DependencyProperty.Register("Count", typeof(int), typeof(EnumerableToVisibilityConverter), new PropertyMetadata(0));

		/// <summary>
		/// Gets or sets the not empty visibility.
		/// </summary>
		public Visibility NotEmptyVisibility
		{
			get => (Visibility) this.GetValue(EnumerableToVisibilityConverter.NotEmptyVisibilityProperty);
			set => this.SetValue(EnumerableToVisibilityConverter.NotEmptyVisibilityProperty, value);
		}

		/// <summary>
		/// Gets or sets the empty visibility.
		/// </summary>
		public Visibility EmptyVisibility
		{
			get => (Visibility) this.GetValue(EnumerableToVisibilityConverter.EmptyVisibilityProperty);
			set => this.SetValue(EnumerableToVisibilityConverter.EmptyVisibilityProperty, value);
		}

		/// <summary>
		/// Gets or sets the count.
		/// </summary>
		public int Count
		{
			get => (int) this.GetValue(EnumerableToVisibilityConverter.CountProperty);
			set => this.SetValue(EnumerableToVisibilityConverter.CountProperty, value);
		}
	}
}
