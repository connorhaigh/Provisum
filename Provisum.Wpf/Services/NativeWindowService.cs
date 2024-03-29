﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Provisum.Services;

namespace Provisum.Wpf.Services
{
	/// <summary>
	/// Represents a native window service.
	/// </summary>
	public sealed class NativeWindowService : IWindowService<Window>
	{
		/// <inheritdoc />
		public void Show(Window window, WindowServiceShowMode mode)
		{
			if (window == null)
			{
				throw new ArgumentNullException(nameof(window));
			}

			window.Owner = this.windows.LastOrDefault();

			EventHandler eventHandler = null;

			window.Closed += eventHandler = (sender, args) =>
			{
				window.Closed -= eventHandler;

				this.windows.Remove(window);
			};

			this.windows.Add(window);

			switch (mode)
			{
				case WindowServiceShowMode.Modeless:
					window.Show();

					break;
				case WindowServiceShowMode.Modal:
					window.ShowDialog();

					break;
			}
		}

		/// <inheritdoc />
		public void Hide(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException(nameof(window));
			}

			window.Hide();

			this.windows.Remove(window);
		}

		private readonly ICollection<Window> windows = new List<Window>();
	}
}
