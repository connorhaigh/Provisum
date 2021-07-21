using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Provisum.Services.Repository
{
	/// <summary>
	/// Represents a JSON file-based repository service.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	public sealed class JsonFileRepositoryService<T> : IRepositoryService<T>
	{
		/// <summary>
		/// Creates a new JSON file repository service instance with the specified file.
		/// </summary>
		/// <param name="file">The file.</param>
		public JsonFileRepositoryService(string file)
		{
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
			if (!File.Exists(this.file))
			{
				return;
			}

			var json = await File.ReadAllTextAsync(this.file);

			this.entities = JsonSerializer.Deserialize<List<T>>(json, JsonFileRepositoryService<T>.options);
		}

		/// <summary>
		/// Saves the entities to file.
		/// </summary>
		/// <returns>A task representing the operation.</returns>
		public async Task Save()
		{
			var json = JsonSerializer.Serialize(this.entities, JsonFileRepositoryService<T>.options);

			await File.WriteAllTextAsync(this.file, json);
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
		public void Update(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			this.entities.Remove(entity);
			this.entities.Add(entity);
		}

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
		public IEnumerable<T> All() => this.entities;

		private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = true,
			AllowTrailingCommas = false,
			IgnoreReadOnlyProperties = true,
			IgnoreReadOnlyFields = true,
			IncludeFields = false
		};

		private readonly string file = null;

		private ICollection<T> entities = new List<T>();
	}
}
