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
		public void HasCorrectName()
		{
			// arrange			
			ActionAdd action = new ActionAdd(this.Writer);

			// act

			// assert
			Assert.AreEqual("Add", action.Name);
		}

		[TestMethod]
		public void HasDescription()
		{
			// arrange			
			ActionAdd action = new ActionAdd(this.Writer);

			// act

			// assert
			Assert.IsFalse(String.IsNullOrEmpty(action.Description));
		}

		[TestMethod]
		public void Compute()
		{
			// arrange			
			ActionAdd action = new ActionAdd(this.Writer);
			
			// act
			action.Action(3, 5);
			action.Action(0, 0);
			action.Action(1, 5);
			action.Action(-3, 5);

			// assert
			Assert.AreEqual("8", this.Lines[0]);
			Assert.AreEqual("0", this.Lines[1]);
			Assert.AreEqual("6", this.Lines[2]);
			Assert.AreEqual("2", this.Lines[3]);
		}
	}
}
