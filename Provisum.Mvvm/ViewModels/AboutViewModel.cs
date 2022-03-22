using System;
using System.Windows.Input;
using Provisum.Services;

namespace Provisum.Mvvm.ViewModels
{
	/// <summary>
	/// Represents an about view model, designed to show information about the application.
	/// </summary>
	public sealed class AboutViewModel : ViewModelBase
	{
		/// <summary>
		/// Creates a new about view model instance with the specified window service and specified application service.
		/// </summary>
		/// <param name="windowService">The window service.</param>
		/// <param name="applicationService">The application service.</param>
		public AboutViewModel(IWindowService<IViewModel> windowService, IApplicationService applicationService)
		{
			this.windowService = windowService ?? throw new ArgumentNullException(nameof(windowService));
			this.applicationService = applicationService ?? throw new ArgumentNullException(nameof(applicationService));

			this.acceptCommand = new ActionCommand(this.Accept);
		}

		private void Accept() => this.windowService.Hide(this);

		/// <summary>
		/// Gets the accept command.
		/// </summary>
		public ICommand AcceptCommand => this.acceptCommand;

		/// <summary>
		/// Gets the product name.
		/// </summary>
		public string Product => this.applicationService.Product;

		/// <summary>
		/// Gets the company name.
		/// </summary>
		public string Company => this.applicationService.Company;

		/// <summary>
		/// Gets the copyright notice.
		/// </summary>
		public string Copyright => this.applicationService.Copyright;

		private readonly IWindowService<IViewModel> windowService = null;
		private readonly IApplicationService applicationService = null;

		private readonly ActionCommand acceptCommand = null;
	}
}
