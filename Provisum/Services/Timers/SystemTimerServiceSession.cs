using System;
using System.Timers;

namespace Provisum.Services.Timers
{
	internal sealed class SystemTimerServiceSession : ITimerServiceSession
	{
		public SystemTimerServiceSession(TimeSpan interval, Action action)
		{
			this.timer = new Timer(interval.TotalMilliseconds)
			{
				Enabled = true,
				AutoReset = true
			};

			this.timer.Elapsed += this.TimerElapsed;

			this.action = action ?? throw new ArgumentNullException(nameof(action));
		}

		public void Start() => this.timer.Start();
		public void Stop() => this.timer.Stop();

		private void TimerElapsed(object sender, ElapsedEventArgs eargs) => this.action?.Invoke();

		private readonly Timer timer = null;
		private readonly Action action = null;
	}
}
