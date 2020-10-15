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

		public void Action(string filename)
		{
			if (String.IsNullOrEmpty(filename)) { throw new ArgumentNullException(nameof(filename)); }

			using (HashAlgorithm hashAlgo = GetHashAlgorithm())
			{
				byte[] data = File.ReadAllBytes(filename);
				byte[] hash = hashAlgo.ComputeHash(data);
				string hex = hash.ToHex();
				this.Writer.WriteLine(hex);
			}
		}

		protected override void Action(string[] parameters)
		{
			if (parameters == null || parameters.Length != 2) { throw new ActionParameterException(); }

			string filename = parameters[1];

			this.Action(filename);
		}
	}
}
