using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Provisum.Wpf.Converters
{
	/// <summary>
	/// Represents a null value to <see cref="Visibility" /> converter.
	/// Returns a specific visibility when the value is either null or not null.
	/// </summary>
	public sealed class NullToVisibilityConverter : DependencyObject, IValueConverter
	{
		/// <inheritdoc />
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				return this.NotNullVisibility;
			}
			else
			{
				return this.NullVisibility;
			}
		}

		/// <inheritdoc />
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

		/// <summary>
		/// Represents the property for when the value is not null.
		/// </summary>
		public static readonly DependencyProperty NotNullVisibilityProperty =
			DependencyProperty.Register("NotNullVisibility", typeof(Visibility), typeof(NullToVisibilityConverter), new PropertyMetadata(Visibility.Collapsed));

		/// <summary>
		/// Represents the property for when the value is null.
		/// </summary>
		public static readonly DependencyProperty NullVisibilityProperty =
			DependencyProperty.Register("NullVisibility", typeof(Visibility), typeof(NullToVisibilityConverter), new PropertyMetadata(Visibility.Visible));

		/// <summary>
		/// Gets or sets the not null visibility.
		/// </summary>
		public Visibility NotNullVisibility
		{
			get => (Visibility) this.GetValue(NullToVisibilityConverter.NotNullVisibilityProperty);
			set => this.SetValue(NullToVisibilityConverter.NotNullVisibilityProperty, value);
		}

		/// <summary>
		/// Gets or sets the null visibility.
		/// </summary>
		public Visibility NullVisibility
		{
			get => (Visibility) this.GetValue(NullToVisibilityConverter.NullVisibilityProperty);
			set => this.SetValue(NullToVisibilityConverter.NullVisibilityProperty, value);
		}
	}
}
