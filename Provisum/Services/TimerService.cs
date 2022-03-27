using System;

namespace Provisum.Services
{
	/// <summary>
	/// Represents a timer service, for executing tasks at repeated intervals.
	/// </summary>
	public interface ITimerService
	{
		/// <summary>
		/// Creates a timer instance that can execute the specified action at the specified interval.
		/// </summary>
		/// <param name="interval">The interval.</param>
		/// <param name="action">The action.</param>
		/// <returns>The instance.</returns>
		ITimerServiceSession Create(TimeSpan interval, Action action);
	}
}
