using FilPasRougeExemple.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExempleTests.Actions
{
	[TestClass]
	public class ActionDivTest : AbstractActionTest
	{
		[TestMethod]
		public void Compute()
		{
			// arrange			
			ActionDiv action = new ActionDiv(this.Writer);
			
			// act
			action.Action(15, 5);
			action.Action(5, 1);
			action.Action(-10, 5);

			// assert
			Assert.AreEqual("3", this.Lines[0]);
			Assert.AreEqual("5", this.Lines[1]);
			Assert.AreEqual("-2", this.Lines[2]);
		}
	}
}
