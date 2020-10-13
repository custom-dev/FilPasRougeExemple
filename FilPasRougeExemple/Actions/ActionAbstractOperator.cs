using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public abstract class ActionAbstractOperator : ActionAbstract
	{
		public ActionAbstractOperator(TextWriter writer): base(writer)
		{
		}

		/// <summary>
		/// Réalise l'opération associé à l'opérateur.
		/// </summary>
		/// Cette méthode est protected, car seules les classes
		/// filles ont besoin d'avoir accès à la méthode.
		/// <param name="f1">Premier nombre</param>
		/// <param name="f2">Deuxième nombre</param>
		/// <returns>Résultat de l'opération</returns>
		protected abstract float Compute(float f1, float f2);

		public override void Action(string[] parameters)
		{
			string n1 = parameters[1];
			string n2 = parameters[2];

			float f1 = float.Parse(n1);
			float f2 = float.Parse(n2);

			float result = this.Compute(f1, f2);
			this.Writer.WriteLine(result);
		}
	}
}
