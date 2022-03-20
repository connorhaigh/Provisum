using System;

namespace Provisum.Services
{
	/// <summary>
	/// Represents a job service, for submitting individual units of work.
	/// </summary>
	public interface IJobService : IService
	{
		/// <summary>
		/// Submits the specified action.
		/// </summary>
		/// <param name="action">The action.</param>
		void Submit(Action action);
	}
}
