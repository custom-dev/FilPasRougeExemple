using FilPasRougeExemple.BusinessLayer;
using FilPasRougeExemple.Services;
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

		public override void Action(string[] parameters)
		{
			string keyFile = parameters[1];
			byte[] key = AesCryptography.GenerateKey();
			this.FileSystem.WriteAllBytes(keyFile, key);
		}
	}
}
