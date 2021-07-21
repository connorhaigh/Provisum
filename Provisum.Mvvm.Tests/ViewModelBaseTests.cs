using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Provisum.Mvvm.Tests
{
	[TestClass]
	public sealed class ViewModelBaseTests
	{
		private sealed class MockViewModelBase : ViewModelBase
		{
			public string SetAndNotifyProperty
			{
				get => this.setAndNotify;
				set => this.SetAndNotify(ref this.setAndNotify, value, nameof(this.SetAndNotifyProperty));
			}

			public string RunAndNotifyProperty
			{
				get => this.runAndNotify;
				set => this.RunAndNotify(() => this.runAndNotify = value, nameof(this.RunAndNotifyProperty));
			}

			private string setAndNotify = null;
			private string runAndNotify = null;
		}

		[TestMethod]
		public void TestSetAndNotify()
		{
			var viewModel = new MockViewModelBase();

			this.viewModelBase.SetAndNotifyProperty = "Jersey";

			Assert.AreEqual(this.viewModelBase.SetAndNotifyProperty, "Jersey");
		}

		[TestMethod]
		public void TestRunAndNotify()
		{
			this.viewModelBase.RunAndNotifyProperty = "Guernsey";

			Assert.AreEqual(this.viewModelBase.RunAndNotifyProperty, "Guernsey");
		}

		[TestMethod]
		public void TestPropertyChangedRaised()
		{
			var propertyNames = new List<string>();

			this.viewModelBase.PropertyChanged += (sender, args) =>
			{
				propertyNames.Add(args.PropertyName);
			};

			this.viewModelBase.SetAndNotifyProperty = "Foo";
			this.viewModelBase.RunAndNotifyProperty = "Bar";

			Assert.AreEqual(propertyNames[0], "SetAndNotifyProperty");
			Assert.AreEqual(propertyNames[1], "RunAndNotifyProperty");
		}

		private readonly MockViewModelBase viewModelBase = new MockViewModelBase();
	}
}
