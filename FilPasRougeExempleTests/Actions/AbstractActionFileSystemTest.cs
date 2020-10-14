using FilPasRougeExemple.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExempleTests.Actions
{
	public abstract class AbstractActionFileSystemTest : AbstractActionTest
	{
		private IFileSystem _fileSystem;

		[TestInitialize]
		public override void Init()
		{
			_fileSystem = Mock.Of<IFileSystem>();
			Mock.Get(_fileSystem)
				.Setup(x => x.ReadAllText(It.Is<string>(s => s.EndsWith("viedemerde.json"))))
				.Returns<string>(x => File.ReadAllText("viedemerde.json"));

			Mock.Get(_fileSystem)
				.Setup(x => x.Exists(It.Is<string>(s => s.EndsWith("viedemerde.json"))))
				.Returns<string>(x => File.Exists("viedemerde.json"));
			base.Init();
		}

		public IFileSystem FileSystem => _fileSystem;
	}
}
