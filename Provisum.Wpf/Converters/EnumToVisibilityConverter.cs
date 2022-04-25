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
	public sealed class EnumToVisibilityConverter : DependencyObject, IValueConverter
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

			throw new ArgumentException("Value is not an enum.", nameof(value));
		}

		/// <inheritdoc />
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

		/// <summary>
		/// Represents the property for the visibility when the value is equal.
		/// </summary>
		public static readonly DependencyProperty TrueVisibilityProperty =
			DependencyProperty.Register("EqualVisibility", typeof(Visibility), typeof(EnumToVisibilityConverter), new PropertyMetadata(Visibility.Visible));

		/// <summary>
		/// Represents the property for the visibility when the value is not equal.
		/// </summary>
		public static readonly DependencyProperty FalseVisibilityProperty =
			DependencyProperty.Register("NotEqualVisibility", typeof(Visibility), typeof(EnumToVisibilityConverter), new PropertyMetadata(Visibility.Collapsed));

		/// <summary>
		/// Represents the property for the value.
		/// </summary>
		public static readonly DependencyProperty ValueProperty =
			DependencyProperty.Register("Value", typeof(Enum), typeof(EnumToVisibilityConverter), new PropertyMetadata(null));

		/// <summary>
		/// Gets or sets the equal visibility.
		/// </summary>
		public Visibility EqualVisibility
		{
			get => (Visibility) this.GetValue(EnumToVisibilityConverter.TrueVisibilityProperty);
			set => this.SetValue(EnumToVisibilityConverter.TrueVisibilityProperty, value);
		}

		/// <summary>
		/// Gets or sets the not equal visibility.
		/// </summary>
		public Visibility NotEqualVisibility
		{
			get => (Visibility) this.GetValue(EnumToVisibilityConverter.FalseVisibilityProperty);
			set => this.SetValue(EnumToVisibilityConverter.FalseVisibilityProperty, value);
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		public Enum Value
		{
			get => (Enum) this.GetValue(EnumToVisibilityConverter.ValueProperty);
			set => this.SetValue(EnumToVisibilityConverter.ValueProperty, value);
		}
	}
}
