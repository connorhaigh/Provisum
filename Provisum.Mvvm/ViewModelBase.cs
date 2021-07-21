using System;
using System.ComponentModel;

namespace Provisum.Mvvm
{
	/// <summary>
	/// Represents a base <see cref="IViewModel" /> implementation. Provides common functionality represented by <see cref="INotifyPropertyChanged" />.
	/// </summary>
	public abstract class ViewModelBase : IViewModel, INotifyPropertyChanged
	{
		/// <summary>
		/// Raises the property changed event for the specified property.
		/// </summary>
		/// <param name="property">The property.</param>
		public void RaisePropertyChanged(string property)
		{
			if (property == null)
			{
				throw new ArgumentNullException(nameof(property));
			}

			this.OnPropertyChanged(new PropertyChangedEventArgs(property));
		}

		/// <summary>
		/// Sets the specified field to the specified value, raising the property changed event for the specified property.
		/// </summary>
		/// <typeparam name="T">The field type.</typeparam>
		/// <param name="field">The field.</param>
		/// <param name="value">The value.</param>
		/// <param name="property">The property.</param>
		protected void SetAndNotify<T>(ref T field, T value, string property)
		{
			if (property == null)
			{
				throw new ArgumentNullException(nameof(property));
			}

			field = value;

			this.OnPropertyChanged(new PropertyChangedEventArgs(property));
		}

		/// <summary>
		/// Runs the specified action, raising the property changed event for the specified property.
		/// </summary>
		/// <param name="action">The action</param>
		/// <param name="property">The property</param>
		protected void RunAndNotify(Action action, string property)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			if (property == null)
			{
				throw new ArgumentNullException(nameof(property));
			}

			action.Invoke();

			this.OnPropertyChanged(new PropertyChangedEventArgs(property));
		}

		/// <summary>
		/// Raises the property changed event.
		/// </summary>
		/// <param name="args">The arguments.</param>
		protected void OnPropertyChanged(PropertyChangedEventArgs args) => this.PropertyChanged?.Invoke(this, args);

		/// <inheritdoc />
		public event PropertyChangedEventHandler PropertyChanged = null;
	}
}
