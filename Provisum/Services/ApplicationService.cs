namespace Provisum.Services
{
	/// <summary>
	/// Represents an application service, for retrieving application information.
	/// </summary>
	public interface IApplicationService : IService
	{
		/// <summary>
		/// Gets the product name.
		/// </summary>
		string Product { get; }

		/// <summary>
		/// Gets the company name.
		/// </summary>
		string Company { get; }

		/// <summary>
		/// Gets the copyright notice.
		/// </summary>
		string Copyright { get; }

		/// <summary>
		/// Gets the version.
		/// </summary>
		string Version { get; }
	}
}
