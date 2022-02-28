using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Provisum.Mvvm
{
	/// <summary>
	/// Represents a base <see cref="IModel" /> implementation. Provides common functionality represented by <see cref="IDataErrorInfo" />.
	/// </summary>
	public abstract class ModelBase : IDataErrorInfo
	{
		/// <summary>
		/// Adds the specified error for the specified property.
		/// </summary>
		/// <param name="property">The property.</param>
		/// <param name="error">The error.</param>
		protected void AddError(string property, string error)
		{
			if (property == null)
			{
				throw new ArgumentNullException(nameof(property));
			}

			if (error == null)
			{
				throw new ArgumentNullException(nameof(error));
			}

			if (this.errors.TryGetValue(property, out var errors))
			{
				errors.Add(error);
			}
			else
			{
				this.errors.Add(property, new List<string>() { error });
			}
		}

		/// <summary>
		/// Removes the errors for the specified property.
		/// </summary>
		/// <param name="property">The property.</param>
		protected void RemoveErrors(string property)
		{
			if (property == null)
			{
				throw new ArgumentNullException(nameof(property));
			}

			this.errors.Remove(property);
		}

		/// <summary>
		/// Removes all the errors.
		/// </summary>
		protected void ClearErrors() => this.errors.Clear();

		/// <inheritdoc />
		public string this[string property]
		{
			get
			{
				if (this.errors.ContainsKey(property))
				{
					return string.Join(", ", this.errors[property].Select(e => $"[{e}]"));
				}

				return null;
			}
		}

		/// <inheritdoc />
		public string Error => this.errors
			.SelectMany(e => e.Value)
			.FirstOrDefault();

		private readonly IDictionary<string, IList<string>> errors = new Dictionary<string, IList<string>>();
	}
}
