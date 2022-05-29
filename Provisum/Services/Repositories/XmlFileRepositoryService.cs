using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Provisum.Services.Repositories
{
	/// <summary>
	/// Represents a XML file-based repository service.
	/// </summary>
	/// <typeparam name="T">The object type.</typeparam>
	public sealed class XmlFileRepositoryService<T> : IRepositoryService<T> where T : class
	{
		/// <summary>
		/// Creates a new XML file repository service instance with the specified file.
		/// </summary>
		/// <param name="fileSystemService">The file system service.</param>
		/// <param name="file">The file.</param>
		public XmlFileRepositoryService(IFileSystemService fileSystemService, string file)
		{
			this.fileSystemService = fileSystemService ?? throw new ArgumentNullException(nameof(fileSystemService));

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
			if (!this.fileSystemService.FileExists(this.file))
			{
				return;
			}

			var xml = await this.fileSystemService.ReadText(this.file);

			using (var stringReader = new StringReader(xml))
			using (var xmlReader = XmlReader.Create(stringReader, readerSettings))
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
			var xml = new StringBuilder();

			using (var stringWriter = new StringWriter(xml))
			using (var xmlWriter = XmlWriter.Create(stringWriter, writerSettings))
			{
				await Task.Run(() => this.serializer.Serialize(xmlWriter, this.entities));
			}

			await this.fileSystemService.WriteText(this.file, xml.ToString());
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
		public void Update(T entity) => throw new NotSupportedException("Cannot update within an file-based XML repository.");

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

		private readonly IFileSystemService fileSystemService = null;

		private readonly string file = null;

		private ICollection<T> entities = new List<T>();
	}
}
