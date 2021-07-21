using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Provisum.Mvvm.Tests
{
	[TestClass]
	public sealed class ModelBaseTests
	{
		private sealed class MockModelBase : ModelBase
		{
			public void AddAlphaError() => this.AddError(nameof(this.Alpha), "Alpha Error");
			public void AddBetaError() => this.AddError(nameof(this.Beta), "Beta Error");
			public void RemoveAlphaErrors() => this.RemoveErrors(nameof(this.Alpha));

			public void Reset() => this.ClearErrors();

			public string Alpha { get; set; } = null;
			public string Beta { get; set; } = null;
		}

		[TestMethod]
		public void TestAddSingleError()
		{
			this.modelBase.AddAlphaError();

			Assert.IsNotNull(this.modelBase["Alpha"]);
		}

		[TestMethod]
		public void TestAddMultipleErrors()
		{
			this.modelBase.AddAlphaError();
			this.modelBase.AddBetaError();

			Assert.IsNotNull(this.modelBase["Alpha"]);
			Assert.IsNotNull(this.modelBase["Beta"]);
		}

		[TestMethod]
		public void TestRemoveSingleError()
		{
			this.modelBase.AddAlphaError();
			this.modelBase.AddBetaError();

			this.modelBase.RemoveAlphaErrors();

			Assert.IsNull(this.modelBase["Alpha"]);
			Assert.IsNotNull(this.modelBase["Beta"]);
		}

		[TestMethod]
		public void TestClearErrors()
		{
			this.modelBase.AddAlphaError();
			this.modelBase.AddBetaError();

			this.modelBase.Reset();

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
