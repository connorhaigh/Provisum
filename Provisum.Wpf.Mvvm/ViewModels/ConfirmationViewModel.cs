using System;
using System.Windows.Input;
using Provisum.Mvvm;
using Provisum.Services;

namespace Provisum.Wpf.Mvvm.ViewModels
{
	/// <summary>
	/// Represents a confirmation view model, designed to prompt for confirmation, with a yes/no option.
	/// </summary>
	public sealed class ConfirmationViewModel : ViewModelBase, IViewModelResultProvider
	{
		/// <summary>
		/// Creates a new confirmation view model instance with the specified services, specified title, and specified message.
		/// </summary>
		/// <param name="windowService">The window service.</param>
		/// <param name="title">The title.</param>
		/// <param name="message">The message.</param>
		public ConfirmationViewModel(IWindowService<IViewModel> windowService, string title, string message)
		{
			this.windowService = windowService ?? throw new ArgumentNullException(nameof(windowService));

			this.title = title;
			this.message = message;

			this.acceptCommand = new ActionCommand(this.Accept);
			this.rejectCommand = new ActionCommand(this.Reject);
		}

		private void Accept()
		{
			this.Result = ViewModelResult.Accept;

			this.windowService.Hide(this);
		}

		private void Reject()
		{
			this.Result = ViewModelResult.Reject;

			this.windowService.Hide(this);
		}

		/// <summary>
		/// Gets the accept command.
		/// </summary>
		public ICommand AcceptCommand => this.acceptCommand;

		/// <summary>
		/// Gets the reject command.
		/// </summary>
		public ICommand RejectCommand => this.rejectCommand;

		/// <inheritdoc />
		public ViewModelResult? Result { get; private set; } = null;

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		public string Title
		{
			get => this.title;
			set => this.SetAndNotify(ref this.title, value, nameof(this.Title));
		}

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		public string Message
		{
			get => this.message;
			set => this.SetAndNotify(ref this.message, value, nameof(this.Message));
		}

		private readonly IWindowService<IViewModel> windowService = null;

		private readonly ActionCommand acceptCommand = null;
		private readonly ActionCommand rejectCommand = null;

		private string title = null;
		private string message = null;
	}
}
