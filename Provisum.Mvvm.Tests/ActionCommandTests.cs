using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Provisum.Mvvm.Tests
{
	[TestClass]
	public sealed class ActionCommandTests
	{
		[TestMethod]
		public void TestExecute()
		{
			var executed = false;
			var command = new ActionCommand(() => executed = true);

			command.Execute(null);

			Assert.IsTrue(executed);
		}

		[TestMethod]
		public void TestCanExecute()
		{
			var canExecute = false;
			var command = new ActionCommand(() => { }, () => canExecute);

			Assert.IsFalse(command.CanExecute(null));

			canExecute = true;

			Assert.IsTrue(command.CanExecute(null));
		}

		[TestMethod]
		public void TestCanExecuteNoPredicate()
		{
			var command = new ActionCommand(() => { });

			Assert.IsTrue(command.CanExecute(null));
		}

		[TestMethod]
		public void TesCanExecuteChangedRaised()
		{
			var command = new ActionCommand(() => { });
			var canExecuteChangedRaised = false;

			command.CanExecuteChanged += (sender, args) =>
			{
				canExecuteChangedRaised = true;
			};

			command.RaiseCanExecuteChanged();

			Assert.IsTrue(canExecuteChangedRaised);
		}
	}
}
