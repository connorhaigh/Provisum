using System;
using System.Collections.Generic;
using System.Windows;
using Provisum.Mvvm;
using Provisum.Services;

namespace Provisum.Wpf.Mvvm.Services
{
	/// <summary>
	/// Represents a view model based window service.
	/// Registers <see cref="IViewModel" /> implementations with the corresponding <see cref="Window" /> implementation.
	/// </summary>
	public sealed class ViewModelWindowService : IWindowService<IViewModel>
	{
		/// <summary>
		/// Creates a new view model window service instance with the specified window service.
		/// </summary>
		/// <param name="windowService">The window service.</param>
		public ViewModelWindowService(IWindowService<Window> windowService)
		{
			this.windowService = windowService ?? throw new ArgumentNullException(nameof(windowService));
		}

		/// <inheritdoc />
		public void Show(IViewModel viewModel, WindowServiceShowMode mode)
		{
			if (viewModel == null)
			{
				throw new ArgumentNullException(nameof(viewModel));
			}

			var viewModelType = viewModel.GetType();

			if (!this.viewModels.TryGetValue(viewModelType, out var viewType))
			{
				throw new ViewModelWindowServiceException("View model type is not registered.");
			}

			if (this.views.ContainsKey(viewModel))
			{
				throw new ViewModelWindowServiceException("View model has already been shown.");
			}

			var view = (Window) Activator.CreateInstance(viewType);

			view.DataContext = viewModel;

			EventHandler eventHandler = null;

			view.Closed += eventHandler = (sender, args) =>
			{
				this.views.Remove(viewModel);

				view.Closed -= eventHandler;
			};

			this.views.Add(viewModel, view);
			this.windowService.Show(view, mode);
		}

		/// <inheritdoc />
		public void Hide(IViewModel viewModel)
		{
			if (viewModel == null)
			{
				throw new ArgumentNullException(nameof(viewModel));
			}

			if (!this.views.TryGetValue(viewModel, out var view))
			{
				throw new ViewModelWindowServiceException("View model is already hidden.");
			}

			this.views.Remove(viewModel);
			this.windowService.Hide(view);
		}

		/// <summary>
		/// Registers the specified view model type with the specified view type.
		/// </summary>
		/// <typeparam name="TViewModel">The view model type.</typeparam>
		/// <typeparam name="TView">The view type.</typeparam>
		public void Register<TViewModel, TView>()
			where TViewModel : IViewModel
			where TView : Window
		{
			var type = typeof(TViewModel);

			if (this.viewModels.ContainsKey(type))
			{
				throw new ViewModelWindowServiceException("View model type has already been registered.");
			}

			this.viewModels.Add(type, typeof(TView));
		}

		private readonly IWindowService<Window> windowService = null;

		private readonly IDictionary<Type, Type> viewModels = new Dictionary<Type, Type>();
		private readonly IDictionary<IViewModel, Window> views = new Dictionary<IViewModel, Window>();
	}

	/// <summary>
	/// Represents a view model window service related exception.
	/// </summary>
	public sealed class ViewModelWindowServiceException : Exception
	{
		internal ViewModelWindowServiceException(string message) : base(message)
		{

		}
	}
}
