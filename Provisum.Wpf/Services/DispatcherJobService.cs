using System;
using System.Windows;
using System.Windows.Threading;
using Provisum.Services;

namespace Provisum.Wpf.Services
{
	/// <summary>
	/// Represents a dispatcher-based job service.
	/// </summary>
	public sealed class DispatcherJobService : IJobService
	{
		/// <summary>
		/// Creates a new dispatcher job service instance for the dispatcher attached to the current application.
		/// </summary>
		/// <returns>The instance.</returns>
		public static DispatcherJobService CreateForCurrentApplicationDispatcher() => new DispatcherJobService(Application.Current.Dispatcher);

		/// <summary>
		/// Creates a new dispatcher job service instance with the specified dispatcher.
		/// </summary>
		/// <param name="dispatcher">The dispatcher.</param>
		public DispatcherJobService(Dispatcher dispatcher)
		{
			this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
		}

		/// <inheritdoc />
		public void Submit(Action action) => this.dispatcher.Invoke(action);

		private readonly Dispatcher dispatcher = null;
	}
}
