using System.Media;
using System.Windows;

namespace Provisum.Wpf.Mvvm.Views
{
	/// <summary>
	/// Represents an input view.
	/// </summary>
	public partial class InputView : Window
	{
		/// <summary>
		/// Creates a new input view instance.
		/// </summary>
		public InputView()
		{
			this.InitializeComponent();
		}

		private void WindowLoaded(object sender, RoutedEventArgs args) => SystemSounds.Beep.Play();
	}
}
