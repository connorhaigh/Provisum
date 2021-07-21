using System.Threading.Tasks;

namespace Provisum.Services
{
	/// <summary>
	/// Represents a file system service, for interacting with a file system.
	/// </summary>
	public interface IFileSystemService : IService
	{
		/// <summary>
		/// Checks if the directory at the specified path.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>If the specified directory exists.</returns>
		bool DirectoryExists(string path);

		/// <summary>
		/// Checks if the file at the specified path exists.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>If the specified file exists.</returns>
		bool FileExists(string path);

		/// <summary>
		/// Creates a directory at the specified path.
		/// </summary>
		/// <param name="path">The path.</param>
		void Create(string path);

		/// <summary>
		/// Deletes the directory at the specified path.
		/// </summary>
		/// <param name="path">The path.</param>
		void DeleteDirectory(string path);

		/// <summary>
		/// Deletes the file at the specified path.
		/// </summary>
		/// <param name="path">The path.</param>
		void DeleteFile(string path);

		/// <summary>
		/// Returns the names of directories at the specified path.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>The directories.</returns>
		string[] GetDirectories(string path);

		/// <summary>
		/// Returns the names of files at the specified path.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>The files.</returns>
		string[] GetFiles(string path);

		/// <summary>
		/// Reads the bytes from the specified file.
		/// </summary>
		/// <param name="path">The file.</param>
		/// <returns>A task representing the operation.</returns>
		Task<byte[]> ReadBytes(string path);

		/// <summary>
		/// Reads the text from the specified file.
		/// </summary>
		/// <param name="path">The file.</param>
		/// <returns>A task representing the operation.</returns>
		Task<string> ReadText(string path);

		/// <summary>
		/// Reads the text line-by-line from the specified file.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>A task representing the operation.</returns>
		Task<string[]> ReadLines(string path);

		/// <summary>
		/// Writes the specified bytes to the specified file.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="bytes">The bytes.</param>
		/// <returns>A task representing the operation.</returns>
		Task WriteBytes(string path, byte[] bytes);

		/// <summary>
		/// Writes the specified text to the specified file.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="text">The text.</param>
		/// <returns>A task representing the operation.</returns>
		Task WriteText(string path, string text);

		/// <summary>
		/// Writes the specified lines to the specified file.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="lines">The lines.</param>
		/// <returns>A task representing the operation.</returns>
		Task WriteLines(string path, string[] lines);

		/// <summary>
		/// Appends the specified text to the specified file.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="text">The text.</param>
		/// <returns>A task representing the operation.</returns>
		Task AppendText(string path, string text);

		/// <summary>
		/// Appends the specified lines to the specified file.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="lines">The lines.</param>
		/// <returns>A task representing the operation.</returns>
		Task AppendLines(string path, string[] lines);
	}
}
