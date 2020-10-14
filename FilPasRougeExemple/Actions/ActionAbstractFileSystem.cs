using FilPasRougeExemple.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public abstract class ActionAbstractFileSystem : ActionAbstract
	{
		private readonly IFileSystem _fileSystem;

		public ActionAbstractFileSystem(TextWriter writer, IFileSystem fileSystem) : base(writer)
		{
			_fileSystem = fileSystem;
		}

		protected IFileSystem FileSystem => _fileSystem;
	}
}
