using System;
using System.IO;

namespace Provisum.Utilities
{
	/// <summary>
	/// Provides environment-related utility methods.
	/// </summary>
	public static class EnvironmentUtilities
	{
		/// <summary>
		/// Returns the application data path for the specified subdirectories, creating the directories if necessary.
		/// </summary>
		/// <param name="subdirectories">The subdirectories.</param>
		/// <returns>The application data path.</returns>
		public static string GetApplicationDataPath(params string[] subdirectories)
		{
			var subdirectoryPath = Path.Combine(subdirectories);
			var applicationDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), subdirectoryPath);

			Directory.CreateDirectory(applicationDataPath);

			return applicationDataPath;
		}
	}
}
