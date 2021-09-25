using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Provisum.Mvvm.Tests
{
	[TestClass]
	public sealed class ViewModelBaseTests
	{
		private sealed class MockViewModelBase : ViewModelBase
		{
			public new void SetAndNotify<T>(ref T field, T value, string property) => base.SetAndNotify(ref field, value, property);
			public new void RunAndNotify(Action action, string property) => base.RunAndNotify(action, property);
		}

		[TestMethod]
		public void TestSetAndNotify()
		{
			var propertyChangedPropertyNames = new List<string>();
			var field = "Field";

			this.viewModelBase.PropertyChanged += (s, e) => propertyChangedPropertyNames.Add(e.PropertyName);
			this.viewModelBase.SetAndNotify(ref field, "SetAndNotify", "SetAndNotifyProperty");

			Assert.AreEqual("SetAndNotify", field);
			Assert.AreEqual("SetAndNotifyProperty", propertyChangedPropertyNames[0]);
		}

		[TestMethod]
		public void TestRunAndNotify()
		{
			var propertyChangedPropertyNames = new List<string>();
			var executed = false;

			this.viewModelBase.PropertyChanged += (s, e) => propertyChangedPropertyNames.Add(e.PropertyName);
			this.viewModelBase.RunAndNotify(() => executed = true, "RunAndNotifyProperty");

			Assert.IsTrue(executed);
			Assert.AreEqual("RunAndNotifyProperty", propertyChangedPropertyNames[0]);
		}

		[TestMethod]
		public void TestRaisePropertyChanged()
		{
			var propertyChangedPropertyNames = new List<string>();

			this.viewModelBase.PropertyChanged += (s, e) => propertyChangedPropertyNames.Add(e.PropertyName);
			this.viewModelBase.RaisePropertyChanged("Property");

			Assert.AreEqual("Property", propertyChangedPropertyNames[0]);
		}

		private readonly MockViewModelBase viewModelBase = new MockViewModelBase();
	}
}
