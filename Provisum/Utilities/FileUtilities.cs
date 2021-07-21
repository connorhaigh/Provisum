namespace Provisum.Utilities
{
	/// <summary>
	/// Provides file-related utility methods.
	/// </summary>
	public static class FileUtilities
	{
		/// <summary>
		/// Returns a humanised file size estimate for the specified size.
		/// </summary>
		/// <param name="size">The size.</param>
		/// <returns>A humanised file size estimate.</returns>
		public static string GetSize(long size)
		{
			if (size < 1024) { return $"{size:N0} bytes"; }
			if (size < 1048576) { return $"{size / 1024:N0} KB"; }
			if (size < 1073741824) { return $"{size / 1048576:N0} MB"; }
			if (size < 1099511627776) { return $"{size / 1073741824:N0} GB"; }

			return $"{size / 1099511627776:N0} TB";
		}
	}
}
