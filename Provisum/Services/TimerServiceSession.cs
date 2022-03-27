namespace Provisum.Services
{
	/// <summary>
	/// Represents a <see cref="ITimerService" /> session.
	/// </summary>
	public interface ITimerServiceSession
	{
		/// <summary>
		/// Starts the timer.
		/// </summary>
		void Start();

		/// <summary>
		/// Stops the timer.
		/// </summary>
		void Stop();
	}
}
