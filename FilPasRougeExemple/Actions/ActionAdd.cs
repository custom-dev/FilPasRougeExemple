using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionAdd : IAction
	{
		private readonly TextWriter _writer;

		public ActionAdd(TextWriter writer)
		{
			_writer = writer;
		}


		public string Name => "Add";

		public string Description => "Calcule la somme des deux nombres passés en paramètre";

		public void Action(string[] parameters)
		{
			string n1 = parameters[1];
			string n2 = parameters[2];

			float f1 = float.Parse(n1);
			float f2 = float.Parse(n2);

			_writer.WriteLine(f1 + f2);
		}
	}
}
