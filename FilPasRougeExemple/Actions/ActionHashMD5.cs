using FilPasRougeExemple.Extensions;
using FilPasRougeExemple.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionHashMD5 : ActionAbstractHash
	{
		public ActionHashMD5(TextWriter writer, IFileSystem fileSystem) : base(writer, fileSystem)
		{
		}

		public override string Name => "HashMD5";

		public override string Description => "Calcule le hash MD5 d'un fichier";

		protected override HashAlgorithm GetHashAlgorithm()
		{
			return MD5.Create();
		}
	}
}
