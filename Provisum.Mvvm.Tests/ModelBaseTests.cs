using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Provisum.Mvvm.Tests
{
	[TestClass]
	public sealed class ModelBaseTests
	{
		private sealed class MockModelBase : ModelBase
		{
			public new void AddError(string property, string error) => base.AddError(property, error);
			public new void RemoveErrors(string property) => base.RemoveErrors(property);
			public new void ClearErrors() => base.ClearErrors();
		}

		[TestMethod]
		public void TestAddSingleError()
		{
			this.modelBase.AddError("Alpha", "Alpha Error");

			Assert.IsNotNull(this.modelBase["Alpha"]);
		}

		[TestMethod]
		public void TestAddMultipleErrors()
		{
			this.modelBase.AddError("Alpha", "Alpha Error");
			this.modelBase.AddError("Beta", "Beta Error");

			Assert.IsNotNull(this.modelBase["Alpha"]);
			Assert.IsNotNull(this.modelBase["Beta"]);
		}

		[TestMethod]
		public void TestRemoveSingleError()
		{
			this.modelBase.AddError("Alpha", "Alpha Error");
			this.modelBase.AddError("Beta", "Beta Error");

			this.modelBase.RemoveErrors("Alpha");

			Assert.IsNull(this.modelBase["Alpha"]);
			Assert.IsNotNull(this.modelBase["Beta"]);
		}

		[TestMethod]
		public void TestClearErrors()
		{
			this.modelBase.AddError("Alpha", "Alpha Error");
			this.modelBase.AddError("Beta", "Beta Error");

			this.modelBase.ClearErrors();

			Assert.IsNull(this.modelBase["Alpha"]);
			Assert.IsNull(this.modelBase["Beta"]);
		}

		[TestMethod]
		public void TestGetNoErrors()
		{
			Assert.IsNull(this.modelBase["Alpha"]);
		}

		private readonly MockModelBase modelBase = new MockModelBase();
	}
}
