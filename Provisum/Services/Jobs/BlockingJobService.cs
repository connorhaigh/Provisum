using System;

namespace Provisum.Services.Jobs
{
	/// <summary>
	/// Represents a single-threaded blocking job service.
	/// </summary>
	public sealed class BlockingJobServices : IJobService
	{
		/// <summary>
		/// Creates a new blocking job service instance.
		/// </summary>
		public BlockingJobServices()
		{

		}

		/// <inheritdoc />
		public void Submit(Action action)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			action.Invoke();
		}
	}
}
