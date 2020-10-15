using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Services
{
	/// <summary>
	/// Implémentation de IFileSystem
	/// </summary>
	public class FileSystem : IFileSystem
	{
		public string ReadAllText(string filename)
		{
			if (String.IsNullOrEmpty(filename)) { throw new ArgumentNullException(nameof(filename)); }

			return File.ReadAllText(filename);
		}

		public void WriteAllText(string filename, string content)
		{
			if (String.IsNullOrEmpty(filename)) { throw new ArgumentNullException(nameof(filename)); }

			File.WriteAllText(filename, content);
		}

		public bool Exists(string filename)
		{
			if (String.IsNullOrEmpty(filename)) { throw new ArgumentNullException(nameof(filename)); }
			
			return File.Exists(filename);
		}

		public void CreateDirectory(string path)
		{
			if (String.IsNullOrEmpty(path)) { throw new ArgumentNullException(nameof(path)); }
			
			Directory.CreateDirectory(path);
		}

		public byte[] ReadAllBytes(string filename)
		{
			if (String.IsNullOrEmpty(filename)) { throw new ArgumentNullException(nameof(filename)); }
			
			return File.ReadAllBytes(filename);
		}

		public void WriteAllBytes(string filename, byte[] data)
		{
			if (String.IsNullOrEmpty(filename)) { throw new ArgumentNullException(nameof(filename)); }
			
			File.WriteAllBytes(filename, data);
		}
	}
}
