namespace Provisum.Mvvm
{
	/// <summary>
	/// Represents a view model result.
	/// </summary>
	public enum ViewModelResult
	{
		/// <summary>
		/// Represents rejection.
		/// </summary>
		Reject,

		/// <summary>
		/// Represents acceptance.
		/// </summary>
		Accept,

		/// <summary>
		/// Represents to retry.
		/// </summary>
		Retry,

		/// <summary>
		/// Represents to ignore.
		/// </summary>
		Ignore
	}
}
