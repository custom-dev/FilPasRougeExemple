using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionHello : ActionAbstract
	{
		public ActionHello(TextWriter writer): base(writer)
		{
		}

		public override string Name => "Hello";

		public override string Description => "Affiche 'Hello World'";

		public override void Action(string[] parameters)
		{
			this.Writer.WriteLine("Hello World");
		}
	}
}
