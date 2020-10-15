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

		public void Action(string keyFile, string inputFile)
		{
			if (String.IsNullOrEmpty(keyFile)) { throw new ArgumentNullException(nameof(keyFile)); }
			if (String.IsNullOrEmpty(inputFile)) { throw new ArgumentNullException(nameof(inputFile)); }
			if (!this.FileSystem.Exists(keyFile)) { throw new FileNotFoundException(keyFile); }
			if (!this.FileSystem.Exists(inputFile)) { throw new FileNotFoundException(inputFile); }

			string outputFile = inputFile.Replace(".encrypted", ".decrypted");

			byte[] key = this.FileSystem.ReadAllBytes(keyFile);
			byte[] encrytpedData = this.FileSystem.ReadAllBytes(inputFile);
			byte[] clearData = AesCryptography.DecryptWithAes(encrytpedData, key);

			this.FileSystem.WriteAllBytes(outputFile, clearData);
		}
		protected override void Action(string[] parameters)
		{
			if (parameters == null || parameters.Length != 3) { throw new ActionParameterException(ActionParameterException.INVALID_PARAMETER_COUNT); }

			string keyFile = parameters[1];
			string inputFile = parameters[2];

			this.Action(keyFile, inputFile);
		}
	}
}
