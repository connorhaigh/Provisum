using System;
using System.Windows;
using Microsoft.Win32;
using Provisum.Desktop.Services;

namespace Provisum.Wpf.Services
{
	/// <summary>
	/// Represents a default dialog service.
	/// </summary>
	public sealed class DefaultDialogService : IDialogService
	{
		/// <inheritdoc />
		public void ShowMessage(string title, string message)
		{
			if (title == null)
			{
				throw new ArgumentNullException(nameof(title));
			}

			if (message == null)
			{
				throw new ArgumentNullException(nameof(message));
			}

			MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
		}

		/// <inheritdoc />
		public bool ShowConfirmation(string title, string message)
		{
			if (title == null)
			{
				throw new ArgumentNullException(nameof(title));
			}

			if (message == null)
			{
				throw new ArgumentNullException(nameof(message));
			}

			return MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes;
		}

		/// <inheritdoc />
		public string ShowOpenFile(string title, string file, string filter)
		{
			var dialog = new OpenFileDialog()
			{
				CheckFileExists = true,
				CheckPathExists = true
			};

			if (title != null) { dialog.Title = title; }
			if (file != null) { dialog.FileName = file; }
			if (filter != null) { dialog.Filter = filter; }

			var result = dialog.ShowDialog();

			if (result == true)
			{
				return dialog.FileName;
			}
			else
			{
				return null;
			}
		}

		/// <inheritdoc />
		public string ShowSaveFile(string title, string file, string filter)
		{
			var dialog = new SaveFileDialog()
			{
				CheckFileExists = true,
				CheckPathExists = true
			};

			if (title != null) { dialog.Title = title; }
			if (file != null) { dialog.FileName = file; }
			if (filter != null) { dialog.Filter = filter; }

			var result = dialog.ShowDialog();

			if (result == true)
			{
				return dialog.FileName;
			}
			else
			{
				return null;
			}
		}
	}
}
