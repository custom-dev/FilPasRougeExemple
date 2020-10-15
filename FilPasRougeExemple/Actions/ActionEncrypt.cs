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

		public void Action(string keyFile, string inputFile)
		{
			if (String.IsNullOrEmpty(keyFile)) { throw new ArgumentNullException(nameof(keyFile)); }
			if (String.IsNullOrEmpty(inputFile)) { throw new ArgumentNullException(nameof(inputFile)); }
			if (!this.FileSystem.Exists(keyFile)) { throw new FileNotFoundException(keyFile); }
			if (!this.FileSystem.Exists(inputFile)) { throw new FileNotFoundException(inputFile); }

			string outputFile = inputFile + ".encrypted";

			byte[] key = this.FileSystem.ReadAllBytes(keyFile);
			byte[] clearData = this.FileSystem.ReadAllBytes(inputFile);
			byte[] encrytpedData = AesCryptography.EncryptWithAes(clearData, key);

			this.FileSystem.WriteAllBytes(outputFile, encrytpedData);
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
