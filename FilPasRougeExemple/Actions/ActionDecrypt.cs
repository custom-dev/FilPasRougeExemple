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
	public class ActionDecrypt : ActionAbstractFileSystem
	{
		public ActionDecrypt(TextWriter writer, IFileSystem fileSystem): base(writer, fileSystem)
		{
		}

		public override string Name => "Decrypt";

		public override string Description => "Déchiffre un fichier";

		public override void Action(string[] parameters)
		{
			string keyFile = parameters[1];
			string inputFile = parameters[2];
			string outputFile = inputFile.Replace(".encrypted", ".decrypted");

			byte[] key = this.FileSystem.ReadAllBytes(keyFile);
			byte[] encrytpedData = this.FileSystem.ReadAllBytes(inputFile);
			byte[] clearData = AesCryptography.DecryptWithAes(encrytpedData, key);

			this.FileSystem.WriteAllBytes(outputFile, clearData);
		}
	}
}
