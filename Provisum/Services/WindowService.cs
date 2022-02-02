namespace Provisum.Services
{
	/// <summary>
	/// Represents a window service, for showing and hiding windows.
	/// </summary>
	/// <typeparam name="T">The window type.</typeparam>
	public interface IWindowService<T> : IService
	{
		/// <summary>
		/// Shows the specified window using the specified mode.
		/// </summary>
		/// <param name="window">The window.</param>
		/// <param name="mode">The mode.</param>
		void Show(T window, WindowServiceShowMode mode);

		/// <summary>
		/// Hides the specified window.
		/// </summary>
		/// <param name="window">The window.</param>
		void Hide(T window);
	}

	/// <summary>
	/// Represents a <see cref="IWindowService{T}" /> show mode.
	/// </summary>
	public enum WindowServiceShowMode
	{
		/// <summary>
		/// Represents modeless (non-blocking).
		/// </summary>
		Modeless,

		/// <summary>
		/// Represents modal (blocking).
		/// </summary>
		Modal
	}
}
