using System;
using System.Collections.Generic;

namespace Provisum.Extensions
{
	/// <summary>
	/// Provides <see cref="IList{T}" /> extension methods.
	/// </summary>
	public static class ListExtensions
	{
		/// <summary>
		/// Swaps the element at the first specified index with the element at the second specified index.
		/// </summary>
		/// <typeparam name="T">The list type.</typeparam>
		/// <param name="list">The list.</param>
		/// <param name="a">The first index.</param>
		/// <param name="b">The second index.</param>
		/// <returns>The swapped element.</returns>
		public static T Swap<T>(this IList<T> list, int a, int b)
		{
			if (list == null)
			{
				throw new ArgumentNullException(nameof(list));
			}

			if (a < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(a), "First index cannot be less than zero.");
			}

			if (b < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(a), "Second index cannot be less than zero.");
			}

			if (a >= list.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(a), "First index cannot be greater than the size of the list.");
			}

			if (b >= list.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(a), "Second index cannot be greater than the size of the list.");
			}

			var element = list[a];

			list[a] = list[b];
			list[b] = element;

			return element;
		}
	}
}
