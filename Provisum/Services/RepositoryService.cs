using System.Collections.Generic;

namespace Provisum.Services
{
	/// <summary>
	/// Represents a repository service, for persisting the instances of multiple objects.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	public interface IRepositoryService<T> : IService
	{
		/// <summary>
		/// Adds the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Add(T entity);

		/// <summary>
		/// Updates the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Update(T entity);

		/// <summary>
		/// Removes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Remove(T entity);

		/// <summary>
		/// Clears all the entities.
		/// </summary>
		void Clear();

		/// <summary>
		/// Returns all the entities.
		/// </summary>
		IEnumerable<T> All();
	}
}
