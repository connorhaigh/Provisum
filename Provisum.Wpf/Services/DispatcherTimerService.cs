using System;
using System.Windows;
using System.Windows.Threading;
using Provisum.Services;

namespace Provisum.Wpf.Services
{
	/// <summary>
	/// Represents a <see cref="Dispatcher "/> based timer service.
	/// </summary>
	public sealed class DispatcherTimerService : ITimerService
	{
		private sealed class Session : ITimerServiceSession
		{
			public Session(Dispatcher dispatcher, TimeSpan interval, Action action)
			{
				this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
				this.action = action ?? throw new ArgumentNullException(nameof(action));

				this.dispatcherTimer = new DispatcherTimer(interval, DispatcherPriority.Normal, this.DispatcherTimerTick, this.dispatcher);
			}

			public void Start() => this.dispatcherTimer.Start();
			public void Stop() => this.dispatcherTimer.Stop();

			private void DispatcherTimerTick(object sender, EventArgs args) => this.action.Invoke();

			private readonly Dispatcher dispatcher = null;
			private readonly Action action = null;

			private readonly DispatcherTimer dispatcherTimer = null;
		}

		/// <summary>
		/// Creates a new dispatcher timer service instance for the dispatcher attached to the current application.
		/// </summary>
		/// <returns>The instance.</returns>
		public static DispatcherTimerService CreateForCurrentApplicationDispatcher() => new DispatcherTimerService(Application.Current.Dispatcher);

		/// <summary>
		/// Creates a new dispatcher timer service instance with the specified dispatcher.
		/// </summary>
		/// <param name="dispatcher">The dispatcher.</param>
		public DispatcherTimerService(Dispatcher dispatcher)
		{
			this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
		}

		/// <inheritdoc />
		public ITimerServiceSession Create(TimeSpan interval, Action action)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			return new Session(this.dispatcher, interval, action);
		}

		private readonly Dispatcher dispatcher = null;
	}
}
