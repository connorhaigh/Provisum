using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Provisum.Services.Repository
{
	/// <summary>
	/// Represents a XML file-based repository service.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	public sealed class XmlFileRepositoryService<T> : IRepositoryService<T>
	{
		/// <summary>
		/// Creates a new XML file repository service instance with the specified file.
		/// </summary>
		/// <param name="file">The file.</param>
		public XmlFileRepositoryService(string file)
		{
			if (file == null)
			{
				throw new ArgumentNullException(nameof(file));
			}

			this.file = Path.ChangeExtension(file, ".xml");
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

			var xml = await File.ReadAllTextAsync(this.file);

			using (var streamReader = new StringReader(xml))
			using (var xmlReader = XmlReader.Create(streamReader, XmlFileRepositoryService<T>.readerSettings))
			{
				await Task.Run(() => this.entities = (List<T>) this.serializer.Deserialize(xmlReader));
			}
		}

		/// <summary>
		/// Saves the entities to file.
		/// </summary>
		/// <returns>A task representing the operation.</returns>
		public async Task Save()
		{
			using (var streamWriter = new StreamWriter(this.file))
			using (var xmlWriter = XmlWriter.Create(streamWriter, XmlFileRepositoryService<T>.writerSettings))
			{
				await Task.Run(() => this.serializer.Serialize(xmlWriter, this.entities));
			}
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
		public void Update(T entity) => throw new NotSupportedException("Cannot update within an XML repository.");

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

		private static readonly XmlReaderSettings readerSettings = new XmlReaderSettings()
		{
			ConformanceLevel = ConformanceLevel.Document,
			IgnoreComments = true,
			IgnoreWhitespace = true
		};

		private static readonly XmlWriterSettings writerSettings = new XmlWriterSettings()
		{
			ConformanceLevel = ConformanceLevel.Document
		};

		private readonly XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

		private readonly string file = null;

		private ICollection<T> entities = new List<T>();
	}
}
