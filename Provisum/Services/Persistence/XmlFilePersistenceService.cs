using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Provisum.Services.Persistence
{
	/// <summary>
	/// Represents a XML file-based persistence service.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	public sealed class XmlFilePersistenceService<T> : IPersistenceService<T> where T : class
	{
		/// <summary>
		/// Creates a new XML file persistence service instance with the specified file and specified entity.
		/// </summary>
		/// <param name="fileSystemService">The file system service.</param>
		/// <param name="file">The file.</param>
		/// <param name="entity">The entity.</param>
		public XmlFilePersistenceService(IFileSystemService fileSystemService, string file, T entity)
		{
			this.fileSystemService = fileSystemService ?? throw new ArgumentNullException(nameof(fileSystemService));

			if (file == null)
			{
				throw new ArgumentNullException(nameof(file));
			}

			this.file = Path.ChangeExtension(file, ".xml");

			this.entity = entity;
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

			var xml = await this.fileSystemService.ReadText(this.file);

			using (var stringReader = new StringReader(xml))
			using (var xmlReader = XmlReader.Create(stringReader, XmlFilePersistenceService<T>.readerSettings))
			{
				await Task.Run(() => this.entity = (T) this.serializer.Deserialize(xmlReader));
			}
		}

		/// <summary>
		/// Saves the entity to file.
		/// </summary>
		/// <returns>A task representing the operation.</returns>
		public async Task Save()
		{
			var xml = new StringBuilder();

			using (var stringWriter = new StringWriter(xml))
			using (var xmlWriter = XmlWriter.Create(stringWriter, XmlFilePersistenceService<T>.writerSettings))
			{
				await Task.Run(() => this.serializer.Serialize(xmlWriter, this.entity));
			}

			await this.fileSystemService.WriteText(this.file, xml.ToString());
		}

		/// <inheritdoc />
		public T Entity
		{
			get => this.entity;
			set => this.entity = value ?? throw new ArgumentNullException(nameof(value));
		}

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

		private readonly XmlSerializer serializer = new XmlSerializer(typeof(T));

		private readonly IFileSystemService fileSystemService = null;
		private readonly string file = null;

		private T entity = null;
	}
}
