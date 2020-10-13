using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public abstract class ActionAbstract : IAction
	{
		private readonly TextWriter _writer;

		public ActionAbstract(TextWriter writer)
		{
			_writer = writer;
		}

		protected TextWriter Writer => _writer;

		public abstract string Name { get; }

		public abstract string Description { get; }

		public abstract void Action(string[] parameters);
	}
}
