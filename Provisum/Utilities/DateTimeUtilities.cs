namespace Provisum.Utilities
{
	/// <summary>
	/// Provides date and time related utility methods.
	/// </summary>
	public static class DateTimeUtilities
	{
		/// <summary>
		/// Returns a humanised time ago estimate string for the specified seconds.
		/// </summary>
		/// <param name="seconds">The seconds.</param>
		/// <returns>A humanised time ago estimate.</returns>
		public static string GetTimeAgo(long seconds)
		{
			if (seconds < 15)
			{
				return "Now";
			}

			if (seconds < 60) { return $"{seconds} seconds ago"; }
			if (seconds < 3600) { return $"{seconds / 60} minutes ago"; }
			if (seconds < 86400) { return $"{seconds / 3600} hours ago"; }
			if (seconds < 604800) { return $"{seconds / 86400} days ago"; }
			if (seconds < 2592000) { return $"{seconds / 604800} weeks ago"; }
			if (seconds < 31622400) { return $"{seconds / 2592000} months ago"; }

			return $"{seconds / 31622400} years ago";
		}
	}
}
