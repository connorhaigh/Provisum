namespace Provisum.Desktop.Services
{
	/// <summary>
	/// Represents a dialog service, for showing common dialogs.
	/// </summary>
	public interface IDialogService : IService
	{
		/// <summary>
		/// Shows a message dialog with the specified title and specified message.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="message">The message.</param>
		void ShowMessage(string title, string message);

		/// <summary>
		/// Shows a confirmation dialog with the specified title and specified message.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="message">The message.</param>
		/// <returns>The response.</returns>
		bool ShowConfirmation(string title, string message);

		/// <summary>
		/// Shows an open file dialog.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="file">The file.</param>
		/// <param name="filter">The filter.</param>
		/// <returns>The path.</returns>
		string ShowOpenFile(string title, string file, string filter);

		/// <summary>
		/// Shows a save file dialog.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="file">The file.</param>
		/// <param name="filter">The filter.</param>
		/// <returns>The path.</returns>
		string ShowSaveFile(string title, string file, string filter);
	}
}
