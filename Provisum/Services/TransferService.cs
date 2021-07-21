using System.Threading.Tasks;

namespace Provisum.Services
{
	/// <summary>
	/// Represents a transfer service, for downloading bytes and uploading bytes.
	/// </summary>
	public interface ITransferService : IService
	{
		/// <summary>
		/// Downloads the bytes from the specified URI.
		/// </summary>
		/// <param name="uri">The URI.</param>
		/// <returns>A task representing the operation.</returns>
		Task<byte[]> Download(string uri);

		/// <summary>
		/// Uploads the specified bytes to the specified URI.
		/// </summary>
		/// <param name="uri">The URI.</param>
		/// <param name="bytes">The bytes.</param>
		/// <returns>A task representing the operation.</returns>
		Task Upload(string uri, byte[] bytes);
	}
}
