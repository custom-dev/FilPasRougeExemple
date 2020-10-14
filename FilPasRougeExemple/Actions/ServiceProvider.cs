using FilPasRougeExemple.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ServiceProvider : IServiceProvider
	{
		private static IFileSystem _fileSystem = new FileSystem();

		public object GetService(Type serviceType)
		{
			switch (serviceType)
			{
				case Type t when t == typeof(TextWriter):
					return Console.Out;
				case Type t when t == typeof(IFileSystem):
					return _fileSystem;
				default:
					return null;
			}
		}
	}
}
