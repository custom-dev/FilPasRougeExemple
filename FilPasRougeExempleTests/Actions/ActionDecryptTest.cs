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
	public class ActionDecryptTest : AbstractActionFileSystemTest
	{
		[TestMethod]
		[DeploymentItem("../../../Datas/BusinessLayer/personnal-test.key")]
		[DeploymentItem("../../../Datas/BusinessLayer/document_texte.txt")]
		[DeploymentItem("../../../Datas/BusinessLayer/document_texte.txt.encrypted")]
		public void MustGenerateKey()
		{
			string keyFile = "personnal-test.key";
			string originalFile = "document_texte.txt";
			string inputFile = originalFile + ".encrypted";
			string outputFile = originalFile + ".decrypted";

			// arrange			
			ActionDecrypt action = new ActionDecrypt(this.Writer, this.FileSystem);
			if (File.Exists(outputFile))
			{
				File.Delete(outputFile);
			}

			// act
			action.Action(keyFile, inputFile);

			// assert
			Assert.IsTrue(File.Exists(outputFile));
			byte[] decryptedData = File.ReadAllBytes(outputFile);
			byte[] plainData = File.ReadAllBytes(originalFile);

			Assert.AreEqual(plainData.Length, decryptedData.Length);

			for(int i = 0; i < plainData.Length; ++i)
			{
				Assert.AreEqual(plainData[i], decryptedData[i]);
			}
		}		
	}
}
