using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Provisum.Wpf.Extensions
{
	/// <summary>
	/// Provides <see cref="DependencyObject" /> extension methods.
	/// </summary>
	public static class DependencyObjectExtensions
	{
		/// <summary>
		/// Returns the logical children for the specified dependency object.
		/// </summary>
		/// <typeparam name="T">The child type.</typeparam>
		/// <param name="dependencyObject">The dependency object.</param>
		/// <returns>The logical children.</returns>
		public static IEnumerable<T> GetLogicalChildren<T>(this DependencyObject dependencyObject) where T : DependencyObject
		{
			if (dependencyObject == null)
			{
				throw new ArgumentNullException(nameof(dependencyObject));
			}

			foreach (var childObject in LogicalTreeHelper.GetChildren(dependencyObject))
			{
				if (childObject is DependencyObject childDependencyObject)
				{
					if (childDependencyObject is T child)
					{
						yield return child;
					}

					foreach (var childOfChild in DependencyObjectExtensions.GetLogicalChildren<T>(childDependencyObject))
					{
						yield return childOfChild;
					}
				}
			}
		}

		/// <summary>
		/// Returns the visual children for the specified dependency object.
		/// </summary>
		/// <typeparam name="T">The child type.</typeparam>
		/// <param name="dependencyObject">The dependency object.</param>
		/// <returns>The visual children.</returns>
		public static IEnumerable<T> GetVisualChildren<T>(this DependencyObject dependencyObject) where T : DependencyObject
		{
			if (dependencyObject == null)
			{
				throw new ArgumentNullException(nameof(dependencyObject));
			}

			for (var index = 0; index < VisualTreeHelper.GetChildrenCount(dependencyObject); index++)
			{
				var childObject = VisualTreeHelper.GetChild(dependencyObject, index);

				if (childObject is T child)
				{
					yield return child;
				}

				foreach (var childOfChild in DependencyObjectExtensions.GetVisualChildren<T>(childObject))
				{
					yield return childOfChild;
				}
			}
		}
	}
}
