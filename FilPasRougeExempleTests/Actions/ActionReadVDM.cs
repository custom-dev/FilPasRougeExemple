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
	public class ActionReadVDMTest : AbstractActionFileSystemTest
	{
		[TestMethod]
		[DeploymentItem("../../../Datas/Actions/viedemerde.json")]
		public void ReadVDM()
		{
			// arrange			
			ActionReadVDM action = new ActionReadVDM(this.Writer, this.FileSystem);
			
			// act
			action.Action(this.GetParameters("ReadVDM"));

			// assert
			Assert.IsTrue(this.Lines[0].StartsWith("Titre: "));
			Assert.IsTrue(this.Lines[1].StartsWith("Auteur: "));
			Assert.IsTrue(!String.IsNullOrEmpty(this.Lines[2]));
		}

		[TestMethod]
		public void ReadVDM_PasDeDonnees()
		{
			// arrange			
			ActionReadVDM action = new ActionReadVDM(this.Writer, this.FileSystem);

			if (File.Exists("viedemerde.json"))
			{
				File.Delete("viedemerde.json");
			}

			// act
			action.Action(this.GetParameters("ReadVDM"));

			// assert
			Assert.AreEqual("Pas de données.", this.Lines[0]);
		}
	}
}
