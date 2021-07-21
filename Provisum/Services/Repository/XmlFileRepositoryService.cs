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

			using (var stringReader = new StringReader(xml))
			using (var xmlReader = XmlReader.Create(stringReader, XmlFileRepositoryService<T>.readerSettings))
			{
				await Task.Run(() => this.entities = (ICollection<T>) this.serializer.Deserialize(xmlReader));
			}
		}

		/// <summary>
		/// Saves the entities to file.
		/// </summary>
		/// <returns>A task representing the operation.</returns>
		public async Task Save()
		{
			using (var stringWriter = new StreamWriter(this.file))
			using (var xmlWriter = XmlWriter.Create(stringWriter, XmlFileRepositoryService<T>.writerSettings))
			{
				await Task.Run(() => this.serializer.Serialize(xmlWriter, this.entities));
				await File.WriteAllTextAsync(this.file, stringWriter.ToString());
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

		private static readonly XmlReaderSettings readerSettings = new XmlReaderSettings()
		{
			ConformanceLevel = ConformanceLevel.Document,
			IgnoreComments = true,
			IgnoreWhitespace = true
		};

		private static readonly XmlWriterSettings writerSettings = new XmlWriterSettings()
		{
			NamespaceHandling = NamespaceHandling.Default,
			ConformanceLevel = ConformanceLevel.Document,
			Indent = true,
			IndentChars = "\t",
			NewLineChars = "\r\n",
			NewLineOnAttributes = true
		};

		private readonly XmlSerializer serializer = new XmlSerializer(typeof(T));

		private readonly string file = null;

		private ICollection<T> entities = new List<T>();
	}
}
