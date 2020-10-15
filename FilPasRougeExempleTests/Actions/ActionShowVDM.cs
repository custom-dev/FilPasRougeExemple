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
	public class ActionShowVDMTest : AbstractActionTest
	{
		[TestMethod]
		public void ShowVDM()
		{
			// arrange			
			ActionShowVDM action = new ActionShowVDM(this.Writer);
			
			// act
			action.Action();

			// assert
			Assert.IsTrue(this.Lines[0].StartsWith("Titre: "));
			Assert.IsTrue(this.Lines[1].StartsWith("Auteur: "));
			Assert.IsTrue(!String.IsNullOrEmpty(this.Lines[2]));
		}
	}
}
