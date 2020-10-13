using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionHello : IAction
	{
		private readonly TextWriter _writer;

		public ActionHello(TextWriter writer)
		{
			_writer = writer;
		}

		public string Name => "Hello";

		public string Description => "Affiche 'Hello World'";

		public void Action(string[] parameters)
		{
			_writer.WriteLine("Hello World !");
		}
	}
}
