namespace Provisum.Services
{
	/// <summary>
	/// Represents a notification service, for showing notifications.
	/// </summary>
	public interface INotificationService
	{
		/// <summary>
		/// Shows a notification with the specified title and specified message.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="message">The message.</param>
		void Show(string title, string message);
	}
}
