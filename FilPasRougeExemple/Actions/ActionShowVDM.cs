using FilPasRougeExemple.BusinessLayer.VDM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionShowVDM : ActionAbstract
	{
		public ActionShowVDM(TextWriter writer) : base(writer)
		{
		}

		public override string Name => "ShowVDM";

		public override string Description => "Affiche les dernières Vie De Merde";

		public void Action()
		{
			VieDeMerdeService query = new VieDeMerdeService();
			VieDeMerdeCollection vdms = query.GetLastVieDeMerdes();

			vdms.Display(this.Writer);
		}

		protected override void Action(string[] parameters)
		{
			if (parameters == null || parameters.Length != 2) { throw new ActionParameterException(); }

			this.Action();
		}
	}
}
