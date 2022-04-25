using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Provisum.Wpf.Converters
{
	/// <summary>
	/// Represents a <see cref="Enum"/> to <see cref="Visibility" /> converter.
	/// Returns a specific visibility when the value is either equal or not equal.
	/// </summary>
	public sealed class EnumerationToVisibilityConverter : DependencyObject, IValueConverter
	{
		/// <inheritdoc />
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return this.NotEqualVisibility;
			}

			if (value is Enum enumValue)
			{
				if (enumValue.Equals(this.Value))
				{
					return this.EqualVisibility;
				}
				else
				{
					return this.NotEqualVisibility;
				}
			}

			throw new ArgumentException("Value is not an enumeration.", nameof(value));
		}

		/// <inheritdoc />
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

		/// <summary>
		/// Represents the property for the visibility when the value is equal.
		/// </summary>
		public static readonly DependencyProperty TrueVisibilityProperty =
			DependencyProperty.Register("EqualVisibility", typeof(Visibility), typeof(EnumerationToVisibilityConverter), new PropertyMetadata(Visibility.Visible));

		/// <summary>
		/// Represents the property for the visibility when the value is not equal.
		/// </summary>
		public static readonly DependencyProperty FalseVisibilityProperty =
			DependencyProperty.Register("NotEqualVisibility", typeof(Visibility), typeof(EnumerationToVisibilityConverter), new PropertyMetadata(Visibility.Collapsed));

		/// <summary>
		/// Represents the property for the value.
		/// </summary>
		public static readonly DependencyProperty ValueProperty =
			DependencyProperty.Register("Value", typeof(Enum), typeof(EnumerationToVisibilityConverter), new PropertyMetadata(null));

		/// <summary>
		/// Gets or sets the equal visibility.
		/// </summary>
		public Visibility EqualVisibility
		{
			get => (Visibility) this.GetValue(EnumerationToVisibilityConverter.TrueVisibilityProperty);
			set => this.SetValue(EnumerationToVisibilityConverter.TrueVisibilityProperty, value);
		}

		/// <summary>
		/// Gets or sets the not equal visibility.
		/// </summary>
		public Visibility NotEqualVisibility
		{
			get => (Visibility) this.GetValue(EnumerationToVisibilityConverter.FalseVisibilityProperty);
			set => this.SetValue(EnumerationToVisibilityConverter.FalseVisibilityProperty, value);
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		public Enum Value
		{
			get => (Enum) this.GetValue(EnumerationToVisibilityConverter.ValueProperty);
			set => this.SetValue(EnumerationToVisibilityConverter.ValueProperty, value);
		}
	}
}
