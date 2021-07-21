using System;
using System.Reflection;

namespace Provisum.Services.Application
{
	/// <summary>
	/// Represents an <see cref="Assembly" /> application service.
	/// </summary>
	public sealed class AssemblyApplicationService : IApplicationService
	{
		/// <summary>
		/// Creates a new assembly application service instance for the entry assembly.
		/// </summary>
		/// <returns>The instance.</returns>
		public static AssemblyApplicationService CreateForEntryAssembly() => new AssemblyApplicationService(Assembly.GetEntryAssembly());

		/// <summary>
		/// Creates a new assembly application service instance for the executing assembly.
		/// </summary>
		/// <returns>The instance.</returns>
		public static AssemblyApplicationService CreateForExecutingAssembly() => new AssemblyApplicationService(Assembly.GetExecutingAssembly());

		/// <summary>
		/// Creates a new assembly application service with the specified assembly.
		/// </summary>
		/// <param name="assembly">The assembly.</param>
		public AssemblyApplicationService(Assembly assembly)
		{
			this.assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
		}

		/// <inheritdoc />
		public string Product => this.assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product;

		/// <inheritdoc />
		public string Company => this.assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;

		/// <inheritdoc />
		public string Copyright => this.assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;

		/// <inheritdoc />
		public string Version => this.assembly.GetCustomAttribute<AssemblyVersionAttribute>()?.Version;

		private readonly Assembly assembly = null;
	}
}
