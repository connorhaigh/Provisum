using System;
using System.IO;
using System.Net.Http;
using System.Text;
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
				return (T) serializer.Deserialize(xmlReader);
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

			var requestXml = new StringBuilder();

			using (var stringWriter = new StringWriter(requestXml))
			using (var xmlWriter = XmlWriter.Create(stringWriter))
			{
				requestSerializer.Serialize(stringWriter, request);
			}

			var responseMessage = await this.client.PostAsync(uri, new StringContent(requestXml.ToString()));
			var responseXml = await responseMessage.Content.ReadAsStringAsync();

			using (var stringReader = new StringReader(responseXml))
			using (var xmlReader = XmlReader.Create(stringReader))
			{
				return (TResponse) responseSerializer.Deserialize(xmlReader);
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
