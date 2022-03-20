using System;
using System.Windows;
using Provisum.Services;
using Provisum.Wpf.Extensions;

namespace Provisum.Wpf.Services
{
	/// <summary>
	/// Represents a native window service.
	/// </summary>
	public sealed class NativeWindowService : IWindowService<Window>
	{
		/// <inheritdoc />
		public void Show(Window window, WindowServiceShowMode mode)
		{
			if (window == null)
			{
				throw new ArgumentNullException(nameof(window));
			}

			window.Owner = Application.Current.GetLastActiveWindow();

			switch (mode)
			{
				case WindowServiceShowMode.Modeless:
					window.Show();

					break;
				case WindowServiceShowMode.Modal:
					window.ShowDialog();

					break;
			}
		}

		/// <inheritdoc />
		public void Hide(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException(nameof(window));
			}

			window.Hide();
		}
	}
}
