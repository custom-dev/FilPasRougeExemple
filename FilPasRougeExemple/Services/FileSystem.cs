using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Services
{
	public class FileSystem : IFileSystem
	{
		public string ReadAllText(string filename)
		{
			return File.ReadAllText(filename);
		}

		public void WriteAllText(string filename, string content)
		{
			File.WriteAllText(filename, content);
		}

		public bool Exists(string filename)
		{
			return File.Exists(filename);
		}

		public void CreateDirectory(string path)
		{
			Directory.CreateDirectory(path);
		}
	}
}
