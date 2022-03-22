using System.Linq;
using System.Windows;

namespace Provisum.Wpf.Extensions
{
	/// <summary>
	/// Provides <see cref="Application" /> extension methods.
	/// </summary>
	public static class ApplicationExtensions
	{
		/// <summary>
		/// Returns the last active window in the specified application.
		/// </summary>
		/// <param name="application">The application.</param>
		/// <returns>The last active window.</returns>
		public static Window GetLastActiveWindow(this Application application)
		{
			var applicationWindows = application.Windows.OfType<Window>();

			return
				applicationWindows.LastOrDefault(w => w.IsActive) ??
				applicationWindows.LastOrDefault() ??
				application.MainWindow;
		}
	}
}
