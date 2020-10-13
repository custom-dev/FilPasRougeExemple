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
	public class ActionAddTest : AbstractActionTest
	{
		[TestMethod]
		public void Compute()
		{
			// arrange			
			ActionAdd action = new ActionAdd(this.Writer);
			
			// act
			action.Action(this.GetParameters("Add", 3, 5));
			action.Action(this.GetParameters("Add", 0, 0));
			action.Action(this.GetParameters("Add", 1, 5));
			action.Action(this.GetParameters("Add", -3, 5));

			// assert
			Assert.AreEqual("8", this.Lines[0]);
			Assert.AreEqual("0", this.Lines[1]);
			Assert.AreEqual("6", this.Lines[2]);
			Assert.AreEqual("2", this.Lines[3]);
		}
	}
}
