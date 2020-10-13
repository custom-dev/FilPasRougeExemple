using FilPasRougeExemple.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FilPasRougeExempleTests.Actions
{
	[TestClass]
	public class ActionHelloTest : AbstractActionTest
	{
		[TestMethod]
		public void MustShowHelloWorld()
		{
			// arrange			
			ActionHello action = new ActionHello(this.Writer);

			// act
			action.Action(this.GetParameters("Hello"));

			// assert
			Assert.AreEqual("Hello World !", this.Lines[0]);
		}		
	}
}
