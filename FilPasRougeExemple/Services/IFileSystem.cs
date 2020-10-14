using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExemple.Services
{
	public interface IFileSystem
	{
		bool Exists(string filename);
		void CreateDirectory(string path);
		string ReadAllText(string filename);
		byte[] ReadAllBytes(string filename);
		void WriteAllText(string filename, string content);
		void WriteAllBytes(string filename, byte[] data);

	}
}
