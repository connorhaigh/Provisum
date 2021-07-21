using System.Media;
using System.Windows;

namespace Provisum.Wpf.Mvvm.Views
{
	/// <summary>
	/// Represents a confirmation view.
	/// </summary>
	public partial class ConfirmationView : Window
	{
		/// <summary>
		/// Creates a new confirmation view instance.
		/// </summary>
		public ConfirmationView()
		{
			this.InitializeComponent();
		}

		private void WindowLoaded(object sender, RoutedEventArgs args) => SystemSounds.Beep.Play();
	}
}
