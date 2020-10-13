using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ServiceProvider : IServiceProvider
	{
		public object GetService(Type serviceType)
		{
			switch (serviceType)
			{
				case Type t when t == typeof(TextWriter):
					return Console.Out;
				default:
					return null;
			}
		}
	}
}
