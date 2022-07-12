using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provisum.Services
{
	/// <summary>
	/// Represents a notification service, for displaying system notifications.
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
