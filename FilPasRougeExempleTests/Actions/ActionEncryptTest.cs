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
	public class ActionEncryptTest : AbstractActionFileSystemTest
	{
		[TestMethod]
		[DeploymentItem("../../../Datas/BusinessLayer/personnal-test.key")]
		[DeploymentItem("../../../Datas/BusinessLayer/document_texte.txt")]
		public void MustGenerateKey()
		{
			string keyFile = "personnal-test.key";
			string inputFile = "document_texte.txt";
			string outputFile = inputFile + ".encrypted";

			// arrange			
			ActionEncrypt action = new ActionEncrypt(this.Writer, this.FileSystem);
			if (File.Exists(outputFile))
			{
				File.Delete(outputFile);
			}

			// act
			action.Action(keyFile, inputFile);

			// assert
			Assert.IsTrue(File.Exists(outputFile));
			byte[] encryptedData = File.ReadAllBytes(outputFile);
			Assert.IsTrue(encryptedData.Length > 0);
		}		
	}
}
