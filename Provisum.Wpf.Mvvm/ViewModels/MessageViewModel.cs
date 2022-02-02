using System;
using System.Windows.Input;
using Provisum.Mvvm;
using Provisum.Services;

namespace Provisum.Wpf.Mvvm.ViewModels
{
	/// <summary>
	/// Represents a message view model, designed to show information.
	/// </summary>
	public sealed class MessageViewModel : ViewModelBase, IViewModelResultProvider
	{
		/// <summary>
		/// Creates a new message view model with the specified services, specified title and specified message.
		/// </summary>
		/// <param name="windowService">The window service.</param>
		/// <param name="title">The title.</param>
		/// <param name="message">The message.</param>
		public MessageViewModel(IWindowService<IViewModel> windowService, string title, string message)
		{
			this.windowService = windowService ?? throw new ArgumentNullException(nameof(windowService));

			this.title = title;
			this.message = message;

			this.acceptCommand = new ActionCommand(this.Accept);
		}

		private void Accept()
		{
			this.Result = ViewModelResult.Accept;

			this.windowService.Hide(this);
		}

		/// <summary>
		/// Gets the accept command.
		/// </summary>
		public ICommand AcceptCommand => this.acceptCommand;

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

		private string title = null;
		private string message = null;
	}
}
