using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionParameterException : Exception
	{
		public const string INVALID_PARAMETER_COUNT = "Nombre de paramètres invalides";

		public ActionParameterException() : base() { }

		public ActionParameterException(string message) : base(message) { }

		public ActionParameterException(string message, Exception innerException) : base(message, innerException) { }	
	}
}
