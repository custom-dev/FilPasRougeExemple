using FilPasRougeExemple.BusinessLayer;
using FilPasRougeExemple.Services;
using FilPasRougeExemple.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionEncrypt : ActionAbstractFileSystem
	{
		public ActionEncrypt(TextWriter writer, IFileSystem fileSystem): base(writer, fileSystem)
		{
		}

		public override string Name => "Encrypt";

		public override string Description => "Chiffre un fichier";

		public override void Action(string[] parameters)
		{
			string keyFile = parameters[1];
			string inputFile = parameters[2];
			string outputFile = inputFile + ".encrypted";

			byte[] key = this.FileSystem.ReadAllBytes(keyFile);
			byte[] clearData = this.FileSystem.ReadAllBytes(inputFile);
			byte[] encrytpedData = AesCryptography.EncryptWithAes(clearData, key);

			this.FileSystem.WriteAllBytes(outputFile, encrytpedData);
		}
	}
}
