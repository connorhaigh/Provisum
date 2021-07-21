using System.Media;
using System.Windows;

namespace Provisum.Wpf.Mvvm.Views
{
	/// <summary>
	/// Represents a message view.
	/// </summary>
	public partial class MessageView : Window
	{
		/// <summary>
		/// Creates a new message view instance.
		/// </summary>
		public MessageView()
		{
			this.InitializeComponent();
		}

		private void WindowLoaded(object sender, RoutedEventArgs args) => SystemSounds.Beep.Play();
	}
}
