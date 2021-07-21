using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Provisum.Services.Persistence
{
	/// <summary>
	/// Represents a XML file-based persistence service.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	public sealed class XmlFilePersistenceService<T> : IPersistenceService<T>
	{
		/// <summary>
		/// Creates a new XML file persistence service instance with the specified file.
		/// </summary>
		/// <param name="file">The file.</param>
		public XmlFilePersistenceService(string file)
		{
			if (file == null)
			{
				throw new ArgumentNullException(nameof(file));
			}

			this.file = Path.ChangeExtension(file, ".xml");
		}

		/// <summary>
		/// Creates a new XML file persistence service instance with the specified file and specified entity.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <param name="entity">The entity.</param>
		public XmlFilePersistenceService(string file, T entity) : this(file)
		{
			this.Entity = entity;
		}

		/// <summary>
		/// Loads the entity from file.
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
			using (var xmlReader = XmlReader.Create(stringReader, XmlFilePersistenceService<T>.readerSettings))
			{
				await Task.Run(() => this.Entity = (T) this.serializer.Deserialize(xmlReader));
			}
		}

		/// <summary>
		/// Saves the entity to file.
		/// </summary>
		/// <returns>A task representing the operation.</returns>
		public async Task Save()
		{
			using (var stringWriter = new StreamWriter(this.file))
			using (var xmlWriter = XmlWriter.Create(stringWriter, XmlFilePersistenceService<T>.writerSettings))
			{
				await Task.Run(() => this.serializer.Serialize(xmlWriter, this.Entity));
				await File.WriteAllTextAsync(this.file, stringWriter.ToString());
			}
		}

		/// <inheritdoc />
		public T Entity { get; set; } = default;

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
	}
}
