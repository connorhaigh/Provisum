using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Provisum.Services.Repositories
{
	/// <summary>
	/// Represents a JSON file-based repository service.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	public sealed class JsonFileRepositoryService<T> : IRepositoryService<T> where T : class
	{
		/// <summary>
		/// Creates a new JSON file repository service instance with the specified file system service and specified file.
		/// </summary>
		/// <param name="fileSystemService">The file system service.</param>
		/// <param name="file">The file.</param>
		public JsonFileRepositoryService(IFileSystemService fileSystemService, string file)
		{
			this.fileSystemService = fileSystemService ?? throw new ArgumentNullException(nameof(fileSystemService));

			if (file == null)
			{
				throw new ArgumentNullException(nameof(file));
			}

			this.file = Path.ChangeExtension(file, ".json");
		}

		/// <summary>
		/// Loads the entities from file.
		/// </summary>
		/// <returns>A task representing the operation.</returns>
		public async Task Load()
		{
			if (!this.fileSystemService.FileExists(this.file))
			{
				return;
			}

			var json = await this.fileSystemService.ReadText(this.file);

			this.entities = JsonSerializer.Deserialize<List<T>>(json, JsonFileRepositoryService<T>.options);
		}

		/// <summary>
		/// Saves the entities to file.
		/// </summary>
		/// <returns>A task representing the operation.</returns>
		public async Task Save()
		{
			var json = JsonSerializer.Serialize(this.entities, JsonFileRepositoryService<T>.options);

			await this.fileSystemService.WriteText(this.file, json);
		}

		/// <inheritdoc />
		public void Add(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			this.entities.Add(entity);
		}

		/// <inheritdoc />
		public void Update(T entity) => throw new NotSupportedException("Cannot update within a file-based JSON repository.");

		/// <inheritdoc />
		public void Remove(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			this.entities.Remove(entity);
		}

		/// <inheritdoc />
		public void Clear() => this.entities.Clear();

		/// <inheritdoc />
		public IEnumerable<T> All() => this.entities;

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

		private ICollection<T> entities = new List<T>();
	}
}
