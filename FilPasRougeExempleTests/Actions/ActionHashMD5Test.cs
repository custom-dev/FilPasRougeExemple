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
	public class ActionHashMD5Test : AbstractActionFileSystemTest
	{
		[TestMethod]
		[DeploymentItem("../../../Datas/BusinessLayer/VDM/viedemerde.html")]
		public void Compute()
		{
			// arrange			
			ActionHashMD5 action = new ActionHashMD5(this.Writer, this.FileSystem);
			
			// act
			action.Action("viedemerde.html");

			// assert
			Assert.AreEqual("d41969232987b58e0998d16fdbbecb1d", this.Lines[0]);
		}
	}
}
