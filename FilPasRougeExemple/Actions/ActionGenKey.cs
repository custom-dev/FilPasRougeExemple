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
	public class ActionGenKey : ActionAbstractFileSystem
	{
		public ActionGenKey(TextWriter writer, IFileSystem fileSystem) : base(writer, fileSystem)
		{

		}

		public override string Name => "GenKey";

		public override string Description => "Génère une clé avec AES";

		public void Action(string keyFile)
		{
			byte[] key = AesCryptography.GenerateKey();
			this.FileSystem.WriteAllBytes(keyFile, key);
		}

		protected override void Action(string[] parameters)
		{
			if (parameters == null || parameters.Length != 2) { throw new ActionParameterException(); }

			string keyFile = parameters[1];

			this.Action(keyFile);
		}
	}
}
