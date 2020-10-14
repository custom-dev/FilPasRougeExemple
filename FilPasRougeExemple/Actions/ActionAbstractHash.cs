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
	public abstract class ActionAbstractHash : ActionAbstractFileSystem
	{
		public ActionAbstractHash(TextWriter writer, IFileSystem fileSystem) : base(writer, fileSystem)
		{
		}

		protected abstract HashAlgorithm GetHashAlgorithm();

		public override void Action(string[] parameters)
		{
			using (HashAlgorithm hashAlgo = GetHashAlgorithm())
			{
				string filename = parameters[1];
				byte[] data = File.ReadAllBytes(filename);
				byte[] hash = hashAlgo.ComputeHash(data);
				string hex = hash.ToHex();
				this.Writer.WriteLine(hex);
			}
		}
	}
}
