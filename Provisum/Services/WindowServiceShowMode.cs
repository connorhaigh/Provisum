namespace Provisum.Services
{
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
