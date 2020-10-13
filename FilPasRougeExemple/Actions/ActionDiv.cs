using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionDiv : ActionAbstractOperator
	{
		public ActionDiv(TextWriter writer) : base (writer)
		{

		}

		public override string Name => "Div";

		public override string Description => "Calcule la division des deux nombres passés en paramètre";

		protected override float Compute(float f1, float f2)
		{
			return f1 / f2;
		}
	}
}
