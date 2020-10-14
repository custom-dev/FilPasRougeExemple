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

		public override void Action(string[] parameters)
		{
			VieDeMerdeQuery query = new VieDeMerdeQuery();
			VieDeMerdeCollection vdms = query.GetLastVieDeMerdes();

			vdms.Display(this.Writer);			
		}
	}
}
