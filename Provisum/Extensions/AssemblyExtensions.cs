using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Provisum.Extensions
{
	/// <summary>
	/// Provides <see cref="Assembly" /> extension methods.
	/// </summary>
	public static class AssemblyExtensions
	{
		/// <summary>
		/// Returns the types that inherit from the specified type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>The inheriting types.</returns>
		public static IEnumerable<Type> GetInheritingTypes(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			return Assembly.GetAssembly(type).GetTypes().Where(current => current.IsSubclassOf(type) && current.IsClass);
		}

		/// <summary>
		/// Returns the types that implement the specified type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>The implementing types.</returns>
		public static IEnumerable<Type> GetImplementingTypes(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			return Assembly.GetAssembly(type).GetTypes().Where(current => type.IsAssignableFrom(current) && current.IsClass);
		}
	}
}
