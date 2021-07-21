using System;
using System.Windows.Input;

namespace Provisum.Mvvm
{
	/// <summary>
	/// Represents a parameterised action-based command.
	/// </summary>
	/// <typeparam name="T">The parameter type.</typeparam>
	public sealed class ActionCommand<T> : ICommand
	{
		/// <summary>
		/// Creates a new action command instance with the specified action.
		/// </summary>
		/// <param name="action">The action.</param>
		public ActionCommand(Action<T> action)
		{
			this.action = action ?? throw new ArgumentNullException(nameof(action));
		}

		/// <summary>
		/// Creates aa new action command instance with the specified action and specified predicate.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="predicate">The predicate.</param>
		public ActionCommand(Action<T> action, Func<T, bool> predicate) : this(action)
		{
			this.predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
		}

		/// <inheritdoc />
		public void Execute(object parameter) => this.action.Invoke((T) parameter);

		/// <inheritdoc />
		public bool CanExecute(object parameter) => this.predicate?.Invoke((T) parameter) ?? true;

		/// <summary>
		/// Raises the can execute changed event.
		/// </summary>
		public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		/// <inheritdoc />
		public event EventHandler CanExecuteChanged = null;

		private readonly Action<T> action = null;
		private readonly Func<T, bool> predicate = null;
	}
}
