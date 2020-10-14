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
				.Setup(x => x.ReadAllText(It.IsAny<string>()))
				.Returns<string>(x => File.ReadAllText(Path.GetFileName(x)));

			Mock.Get(_fileSystem)
				.Setup(x => x.Exists(It.IsAny<string>()))
				.Returns<string>(x => File.Exists(Path.GetFileName(x)));

			Mock.Get(_fileSystem)
				.Setup(x => x.WriteAllBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
				.Callback<string, byte[]>((filename, data) => File.WriteAllBytes(filename, data));

			Mock.Get(_fileSystem)
				.Setup(x => x.ReadAllBytes(It.IsAny<string>()))
				.Returns<string>(x => File.ReadAllBytes(Path.GetFileName(x)));

			base.Init();
		}

		public IFileSystem FileSystem => _fileSystem;
	}
}
