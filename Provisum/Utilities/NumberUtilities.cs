namespace Provisum.Utilities
{
	/// <summary>
	/// Provides number-related utility methods.
	/// </summary>
	public static class NumberUtilities
	{
		/// <summary>
		/// Returns the ordinal suffix for the specified vlaue.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The ordinal suffix.</returns>
		public static string GetOrdinal(long value)
		{
			var ones = value % 10;
			var tens = (value / 10) % 10;

			if (tens != 1)
			{
				switch (ones)
				{
					case 1: return $"{value}st";
					case 2: return $"{value}nd";
					case 3: return $"{value}rd";
					default: break;
				}
			}

			return $"{value}th";
		}
	}
}
