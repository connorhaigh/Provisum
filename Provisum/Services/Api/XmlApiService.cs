using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Provisum.Services.Api
{
	/// <summary>
	/// Represents a XML-based API service.
	/// </summary>
	public sealed class XmlApiService : IApiService
	{
		/// <summary>
		/// Creates a new XML API service instance.
		/// </summary>
		public XmlApiService()
		{

		}

		/// <inheritdoc />
		public async Task<T> Get<T>(string uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException(nameof(uri));
			}

			var serializer = new XmlSerializer(typeof(T));

			var responseMessage = await this.client.GetAsync(uri);
			var responseXml = await responseMessage.Content.ReadAsStringAsync();

			using (var stringReader = new StringReader(responseXml))
			using (var xmlReader = XmlReader.Create(stringReader))
			{
				var response = (T) serializer.Deserialize(xmlReader);

				return response;
			}
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

			var requestSerializer = new XmlSerializer(typeof(TRequest));
			var responseSerializer = new XmlSerializer(typeof(TResponse));

			using (var stringWriter = new StringWriter())
			using (var xmlWriter = XmlWriter.Create(stringWriter))
			{
				requestSerializer.Serialize(stringWriter, request);

				var requestXml = stringWriter.ToString();

				var responseMessage = await this.client.PostAsync(uri, new StringContent(requestXml));
				var responseXml = await responseMessage.Content.ReadAsStringAsync();

				using (var stringReader = new StringReader(responseXml))
				using (var xmlReader = XmlReader.Create(stringReader))
				{
					var response = (TResponse) responseSerializer.Deserialize(xmlReader);

					return response;
				}
			}
		}

		private readonly HttpClient client = new HttpClient()
		{
			DefaultRequestHeaders =
			{
				{"User-Agent", "Provisum XmlApiService/1.0"}
			}
		};
	}
}
