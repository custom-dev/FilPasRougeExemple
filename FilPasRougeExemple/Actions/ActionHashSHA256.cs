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
	public class ActionHashSHA256 : ActionAbstractHash
	{
		public ActionHashSHA256(TextWriter writer, IFileSystem fileSystem) : base(writer, fileSystem)
		{
		}

		public override string Name => "HashSHA256";

		public override string Description => "Calcule le hash SHA256 d'un fichier";

		protected override HashAlgorithm GetHashAlgorithm()
		{
			return SHA256.Create();
		}
	}
}
