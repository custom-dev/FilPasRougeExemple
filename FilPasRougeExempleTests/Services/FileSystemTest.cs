using FilPasRougeExemple.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExempleTests.Services
{
	/// <summary>
	/// FileSystem implémente l'interface IFileSystem
	/// La classe FileSystemTest dérive donc de IFileSystemTest afin 
	/// de tester la conformité de l'implémentation vis-à-vis de l'interface.
	/// </summary>
	[TestClass]
	public class FileSystemTest : IFileSystemTest
	{
		private IFileSystem _fileSystem;

		public FileSystemTest()
		{
			_fileSystem = new FileSystem();
		}

		/// <summary>
		/// Objet à utiliser pour les tests.
		/// </summary>
		public override IFileSystem FileSystem => _fileSystem;
	}
}
