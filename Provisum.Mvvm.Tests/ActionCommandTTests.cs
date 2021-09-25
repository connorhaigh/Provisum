using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Provisum.Mvvm.Tests
{
	[TestClass]
	public sealed class ActionCommandTTests
	{
		[TestMethod]
		public void TestExecute()
		{
			var executed = false;
			var command = new ActionCommand<object>((a) => executed = true);

			command.Execute(null);

			Assert.IsTrue(executed);
		}

		[TestMethod]
		public void TestExecuteParameter()
		{
			var command = new ActionCommand<string>((argument) =>
			{
				Assert.AreEqual("Argument", argument);
			});

			command.Execute("Argument");
		}

		[TestMethod]
		public void TestCanExecute()
		{
			var canExecute = false;
			var command = new ActionCommand<object>(a => { }, a => canExecute);

			Assert.IsFalse(command.CanExecute(null));

			canExecute = true;

			Assert.IsTrue(command.CanExecute(null));
		}

		[TestMethod]
		public void TestCanExecuteParameter()
		{
			var command = new ActionCommand<string>(a => { }, argument =>
			{
				Assert.AreEqual("Argument", argument);

				return true;
			});

			Assert.IsTrue(command.CanExecute("Argument"));
		}

		[TestMethod]
		public void TestCanExecuteNoPredicate()
		{
			var command = new ActionCommand<object>(a => { });

			Assert.IsTrue(command.CanExecute(null));
		}

		[TestMethod]
		public void TesCanExecuteChangedRaised()
		{
			var canExecuteChangedRaised = false;
			var command = new ActionCommand<object>(a => { });

			command.CanExecuteChanged += (s, e) => canExecuteChangedRaised = true;
			command.RaiseCanExecuteChanged();

			Assert.IsTrue(canExecuteChangedRaised);
		}
	}
}
