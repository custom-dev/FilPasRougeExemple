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
	public class ActionGenKeyTest : AbstractActionFileSystemTest
	{
		[TestMethod]
		public void MustGenerateKey()
		{
			string keyFile = "personnal-test.key";
			// arrange			
			ActionGenKey action = new ActionGenKey(this.Writer, this.FileSystem);
			if (File.Exists(keyFile))
			{
				File.Delete(keyFile);
			}

			// act
			action.Action(keyFile);

			// assert
			Assert.IsTrue(File.Exists(keyFile));
			byte[] keyData = File.ReadAllBytes(keyFile);
			Assert.AreEqual(32, keyData.Length);
		}		
	}
}
