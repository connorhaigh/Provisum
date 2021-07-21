using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Provisum.Wpf.Converters
{
	/// <summary>
	/// Represents a <see cref="bool" /> to <see cref="Visibility" /> converter.
	/// Returns a specific visibility when the value is either true or false.
	/// </summary>
	public sealed class BoolToVisibilityConverter : DependencyObject, IValueConverter
	{
		/// <inheritdoc />
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool boolValue)
			{
				if (boolValue)
				{
					return this.TrueVisibility;
				}
				else
				{
					return this.FalseVisibility;
				}
			}

			throw new ArgumentException("Value is not a bool.", nameof(value));
		}

		/// <inheritdoc />
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

		/// <summary>
		/// Represents the property for when the value is true.
		/// </summary>
		public static readonly DependencyProperty TrueVisibilityProperty =
			DependencyProperty.Register("TrueVisibility", typeof(Visibility), typeof(BoolToVisibilityConverter), new PropertyMetadata(Visibility.Visible));

		/// <summary>
		/// Represents the property for when the value is false.
		/// </summary>
		public static readonly DependencyProperty FalseVisibilityProperty =
			DependencyProperty.Register("FalseVisibility", typeof(Visibility), typeof(BoolToVisibilityConverter), new PropertyMetadata(Visibility.Collapsed));

		/// <summary>
		/// Gets or sets the true visibility.
		/// </summary>
		public Visibility TrueVisibility
		{
			get => (Visibility) this.GetValue(BoolToVisibilityConverter.TrueVisibilityProperty);
			set => this.SetValue(BoolToVisibilityConverter.TrueVisibilityProperty, value);
		}

		/// <summary>
		/// Gets or sets the false visibility.
		/// </summary>
		public Visibility FalseVisibility
		{
			get => (Visibility) this.GetValue(BoolToVisibilityConverter.FalseVisibilityProperty);
			set => this.SetValue(BoolToVisibilityConverter.FalseVisibilityProperty, value);
		}
	}
}
