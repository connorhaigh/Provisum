using System;
using System.Windows.Input;
using Provisum.Services;

namespace Provisum.Mvvm.ViewModels
{
	/// <summary>
	/// Represents a message view model, designed to show information.
	/// </summary>
	public sealed class MessageViewModel : ViewModelBase, IViewModelResultProvider
	{
		/// <summary>
		/// Creates a new message view model instance with the specified window service, specified title, and specified message.
		/// </summary>
		/// <param name="windowService">The window service.</param>
		/// <param name="title">The title.</param>
		/// <param name="message">The message.</param>
		public MessageViewModel(IWindowService<IViewModel> windowService, string title, string message)
		{
			this.windowService = windowService ?? throw new ArgumentNullException(nameof(windowService));

			this.Title = title ?? throw new ArgumentNullException(nameof(title));
			this.Message = message ?? throw new ArgumentNullException(nameof(message));

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
		/// Gets the title.
		/// </summary>
		public string Title { get; } = null;

		/// <summary>
		/// Gets the message.
		/// </summary>
		public string Message { get; } = null;

		private readonly IWindowService<IViewModel> windowService = null;

		private readonly ActionCommand acceptCommand = null;
	}
}
