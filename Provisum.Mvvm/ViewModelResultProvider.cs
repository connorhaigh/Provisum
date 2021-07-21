namespace Provisum.Mvvm
{
	/// <summary>
	/// Represents a <see cref="ViewModelResult" /> provider.
	/// </summary>
	public interface IViewModelResultProvider
	{
		/// <summary>
		/// Gets the result.
		/// </summary>
		ViewModelResult? Result { get; }
	}
}
