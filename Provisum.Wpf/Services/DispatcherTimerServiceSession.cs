using System;
using System.Windows.Threading;
using Provisum.Services;

namespace Provisum.Wpf.Services
{
	internal sealed class DispatcherTimerServiceSession : ITimerServiceSession
	{
		public DispatcherTimerServiceSession(Dispatcher dispatcher, TimeSpan interval, Action action)
		{
			this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
			this.action = action ?? throw new ArgumentNullException(nameof(action));

			this.dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal, this.dispatcher)
			{
				Interval = interval
			};

			this.dispatcherTimer.Tick += this.DispatcherTimerTick;
		}

		public void Start() => this.dispatcherTimer.Start();
		public void Stop() => this.dispatcherTimer.Stop();

		private void DispatcherTimerTick(object sender, EventArgs args) => this.action.Invoke();

		private readonly Dispatcher dispatcher = null;
		private readonly Action action = null;

		private readonly DispatcherTimer dispatcherTimer = null;
	}
}
