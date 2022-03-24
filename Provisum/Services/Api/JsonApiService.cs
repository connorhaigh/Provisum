using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Provisum.Services.Api
{
	/// <summary>
	/// Represents a JSON-based API service.
	/// </summary>
	public sealed class JsonApiService : IApiService
	{
		/// <summary>
		/// Creates a new JSON API service instance.
		/// </summary>
		public JsonApiService()
		{

		}

		/// <inheritdoc />
		public async Task<T> Get<T>(string uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException(nameof(uri));
			}

			var responseMessage = await this.client.GetAsync(uri);
			var responseJson = await responseMessage.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<T>(responseJson);
		}

		/// <inheritdoc />
		public async Task<TResponse> Post<TRequest, TResponse>(string uri, TRequest request)
		{
			if (uri == null)
			{
				throw new ArgumentNullException(nameof(uri));
			}

			if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			var requestJson = JsonSerializer.Serialize(request);

			var responseMessage = await this.client.PostAsync(uri, new StringContent(requestJson));
			var responseJson = await responseMessage.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<TResponse>(responseJson);
		}

		private readonly HttpClient client = new HttpClient()
		{
			DefaultRequestHeaders =
			{
				{"User-Agent", "Provisum JsonApiService/1.0"}
			}
		};
	}
}
