using System;
using System.IO;
using System.Threading.Tasks;
using Provisum.Utilities;

namespace Provisum.Services.FileSystems
{
	/// <summary>
	/// Represents a local file system service.
	/// </summary>
	public sealed class LocalFileSystemService : IFileSystemService
	{
		/// <summary>
		/// Creates a new local file system service instance within the application data directory for the specified subdirectories.
		/// </summary>
		/// <param name="subdirectories">The subdirectories.</param>
		/// <returns>The instance.</returns>
		public static LocalFileSystemService CreateForApplicationDataDirectory(params string[] subdirectories) => new LocalFileSystemService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine(subdirectories)));

		/// <summary>
		/// Creates a new local file system service instance for the current working directory.
		/// </summary>
		/// <returns>The instance.</returns>
		public static LocalFileSystemService CreateForCurrentDirectory() => new LocalFileSystemService(Environment.CurrentDirectory);

		/// <summary>
		/// Creates a new local file system service for the specified path.
		/// </summary>
		/// <param name="path">The path.</param>
		public LocalFileSystemService(string path)
		{
			this.path = path ?? throw new ArgumentNullException(nameof(path));
		}

		/// <inheritdoc />
		public bool DirectoryExists(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			return Directory.Exists(Path.Combine(this.path, path));
		}

		/// <inheritdoc />
		public bool FileExists(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			return File.Exists(Path.Combine(this.path, path));
		}

		/// <inheritdoc />
		public void Create(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			Directory.CreateDirectory(Path.Combine(this.path, path));
		}

		/// <inheritdoc />
		public void DeleteDirectory(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			Directory.Delete(Path.Combine(this.path, path));
		}

		/// <inheritdoc />
		public void DeleteFile(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			File.Delete(Path.Combine(this.path, path));
		}

		/// <inheritdoc />
		public string[] GetDirectories(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			return Directory.GetDirectories(path);
		}

		/// <inheritdoc />
		public string[] GetFiles(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			return Directory.GetFiles(path);
		}

		/// <inheritdoc />
		public async Task<byte[]> ReadBytes(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			return await File.ReadAllBytesAsync(Path.Combine(this.path, path));
		}

		/// <inheritdoc />
		public async Task<string> ReadText(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			return await File.ReadAllTextAsync(Path.Combine(this.path, path));
		}

		/// <inheritdoc />
		public async Task<string[]> ReadLines(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			return await File.ReadAllLinesAsync(Path.Combine(this.path, path));
		}

		/// <inheritdoc />
		public async Task WriteBytes(string path, byte[] bytes)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			if (bytes == null)
			{
				throw new ArgumentNullException(nameof(bytes));
			}

			Directory.CreateDirectory(this.path);

			await File.WriteAllBytesAsync(Path.Combine(this.path, path), bytes);
		}

		/// <inheritdoc />
		public async Task WriteText(string path, string text)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			if (text == null)
			{
				throw new ArgumentNullException(nameof(text));
			}

			Directory.CreateDirectory(this.path);

			await File.WriteAllTextAsync(Path.Combine(this.path, path), text);
		}

		/// <inheritdoc />
		public async Task WriteLines(string path, string[] lines)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			if (lines == null)
			{
				throw new ArgumentNullException(nameof(lines));
			}

			Directory.CreateDirectory(this.path);

			await File.WriteAllLinesAsync(Path.Combine(this.path, path), lines);
		}

		/// <inheritdoc />
		public async Task AppendText(string path, string text)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			if (text == null)
			{
				throw new ArgumentNullException(nameof(text));
			}

			Directory.CreateDirectory(this.path);

			await File.AppendAllTextAsync(Path.Combine(this.path, path), text);
		}

		/// <inheritdoc />
		public async Task AppendLines(string path, string[] lines)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			if (lines == null)
			{
				throw new ArgumentNullException(nameof(lines));
			}

			Directory.CreateDirectory(this.path);

			await File.AppendAllLinesAsync(Path.Combine(this.path, path), lines);
		}

		private readonly string path = null;
	}
}
