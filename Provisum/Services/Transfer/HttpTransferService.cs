using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Provisum.Services.Download
{
	/// <summary>
	/// Represents a HTTP-based transfer service.
	/// </summary>
	public sealed class HttpTransferService : ITransferService
	{
		/// <summary>
		/// Creates a new HTTP transfer service instance.
		/// </summary>
		public HttpTransferService()
		{

		}

		/// <inheritdoc />
		public async Task<byte[]> Download(string uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException(nameof(uri));
			}

			var response = await this.client.GetAsync(uri);
			var bytes = await response.Content.ReadAsByteArrayAsync();

			return bytes;
		}

		/// <inheritdoc />
		public async Task Upload(string uri, byte[] bytes)
		{
			if (uri == null)
			{
				throw new ArgumentNullException(nameof(uri));
			}

			if (bytes == null)
			{
				throw new ArgumentNullException(nameof(bytes));
			}

			await this.client.PostAsync(uri, new ByteArrayContent(bytes));
		}

		private readonly HttpClient client = new HttpClient()
		{
			DefaultRequestHeaders =
			{
				{"User-Agent", "Provisum HttpTransferService/1.0"}
			}
		};
	}
}
