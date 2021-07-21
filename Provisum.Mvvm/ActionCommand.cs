using System;
using System.Windows.Input;

namespace Provisum.Mvvm
{
	/// <summary>
	/// Represents an action-based command.
	/// </summary>
	public sealed class ActionCommand : ICommand
	{
		/// <summary>
		/// Creates a new action command instance with the specified action.
		/// </summary>
		/// <param name="action">The action.</param>
		public ActionCommand(Action action)
		{
			this.action = action ?? throw new ArgumentNullException(nameof(action));
		}

		/// <summary>
		/// Creates a new action command instance with the specified action and specified predicate.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="predicate">The predicate.</param>
		public ActionCommand(Action action, Func<bool> predicate) : this(action)
		{
			this.predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
		}

		/// <inheritdoc />
		public void Execute(object parameter) => this.action.Invoke();

		/// <inheritdoc />
		public bool CanExecute(object parameter) => this.predicate?.Invoke() ?? true;

		/// <summary>
		/// Raises the can execute changed event.
		/// </summary>
		public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		/// <inheritdoc />
		public event EventHandler CanExecuteChanged = null;

		private readonly Action action = null;
		private readonly Func<bool> predicate = null;
	}
}
