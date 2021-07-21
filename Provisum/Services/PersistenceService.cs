namespace Provisum.Services
{
	/// <summary>
	/// Represents a persistence service, for persisting the instance of a single object.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	public interface IPersistenceService<T> : IService
	{
		/// <summary>
		/// Gets or sets the entity.
		/// </summary>
		T Entity { get; set; }
	}
}
