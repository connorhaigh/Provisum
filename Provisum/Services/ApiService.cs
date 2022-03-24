using System.Threading.Tasks;

namespace Provisum.Services
{
	/// <summary>
	/// Represents an API service, for interacting with web applications.
	/// </summary>
	public interface IApiService : IService
	{
		/// <summary>
		/// Performs a GET request to the specified URI.
		/// </summary>
		/// <typeparam name="T">The response type.</typeparam>
		/// <param name="uri">The URI.</param>
		/// <returns>A task representing the operation.</returns>
		Task<T> Get<T>(string uri) where T : class;

		/// <summary>
		/// Performs a POST request to the specified URI with the specified request.
		/// </summary>
		/// <typeparam name="TRequest">The request type.</typeparam>
		/// <typeparam name="TResponse">The response type.</typeparam>
		/// <param name="uri">The URI.</param>
		/// <param name="request">The request.</param>
		/// <returns>A task representing the operation.</returns>
		Task<TResponse> Post<TRequest, TResponse>(string uri, TRequest request)
			where TRequest : class
			where TResponse : class;
	}
}
