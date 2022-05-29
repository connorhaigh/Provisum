using System;
using System.Timers;

namespace Provisum.Services.Timers
{
	/// <summary>
	/// Represents a <see cref="Timer"/> based timer service.
	/// </summary>
	public sealed class SystemTimerService : ITimerService
	{
		/// <summary>
		/// Creates a new sysstem timer service instance.
		/// </summary>
		public SystemTimerService()
		{

		}

		/// <inheritdoc />
		public ITimerServiceSession Create(TimeSpan interval, Action action)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			return new SystemTimerServiceSession(interval, action);
		}
	}
}
