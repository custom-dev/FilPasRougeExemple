using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionHelloPasTestable : IAction
	{	
		public string Name => "Hello";

		public string Description => "Affiche 'Hello World'";

		public void Action(string[] parameters)
		{
			Console.WriteLine("Hello World !");
		}
	}
}
