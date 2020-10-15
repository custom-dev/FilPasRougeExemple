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
	public class ActionHashSHA256Test : AbstractActionFileSystemTest
	{
		[TestMethod]
		[DeploymentItem("../../../Datas/BusinessLayer/VDM/viedemerde.html")]
		public void Compute()
		{
			// arrange			
			ActionHashSHA256 action = new ActionHashSHA256(this.Writer, this.FileSystem);
			
			// act
			action.Action("viedemerde.html");

			// assert
			Assert.AreEqual("115420f7b6c84e15d86d3c6e692b10a0deb29403d41e4cfc9cbb43d1410a7201", this.Lines[0]);
		}
	}
}
