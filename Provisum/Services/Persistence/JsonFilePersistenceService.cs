using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Provisum.Services.Persistence
{
	/// <summary>
	/// Represents a JSON file-based persistence service.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	public sealed class JsonFilePersistenceService<T> : IPersistenceService<T>
	{
		/// <summary>
		/// Creates a new JSON file persistence service instance with the specified file system service and specified file.
		/// </summary>
		/// <param name="fileSystemService">The file system service.</param>
		/// <param name="file">The file.</param>
		public JsonFilePersistenceService(IFileSystemService fileSystemService, string file)
		{
			this.fileSystemService = fileSystemService ?? throw new ArgumentNullException(nameof(fileSystemService));

			if (file == null)
			{
				throw new ArgumentNullException(nameof(file));
			}

			this.file = Path.ChangeExtension(file, ".json");
		}

		/// <summary>
		/// Creates a new JSON file persistence service instance with the specified file system service, specified file, and specified entity.
		/// </summary>
		/// <param name="fileSystemService">The file system service.</param>
		/// <param name="file">The file.</param>
		/// <param name="entity">The entity.</param>
		public JsonFilePersistenceService(IFileSystemService fileSystemService, string file, T entity) : this(fileSystemService, file)
		{
			this.Entity = entity;
		}

		/// <summary>
		/// Loads the entity from file.
		/// </summary>
		/// <returns>A task representing the operation.</returns>
		public async Task Load()
		{
			if (!this.fileSystemService.FileExists(this.file))
			{
				return;
			}

			var json = await this.fileSystemService.ReadText(this.file);

			this.Entity = JsonSerializer.Deserialize<T>(json, JsonFilePersistenceService<T>.options);
		}

		/// <summary>
		/// Saves the entity to file.
		/// </summary>
		/// <returns>A task representing the operation.</returns>
		public async Task Save()
		{
			var json = JsonSerializer.Serialize(this.Entity, JsonFilePersistenceService<T>.options);

			await this.fileSystemService.WriteText(this.file, json);
		}

		/// <inheritdoc />
		public T Entity { get; set; } = default;

		private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
			IgnoreReadOnlyProperties = true,
			IgnoreReadOnlyFields = true,
			IncludeFields = false,
			AllowTrailingCommas = false
		};

		private readonly IFileSystemService fileSystemService = null;

		private readonly string file = null;
	}
}
