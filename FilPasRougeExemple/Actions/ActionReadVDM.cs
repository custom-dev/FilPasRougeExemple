using FilPasRougeExemple.BusinessLayer.VDM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionReadVDM : ActionAbstract
	{
		public ActionReadVDM(TextWriter writer) : base(writer)
		{
		}

		public override string Name => "ReadVDM";

		public override string Description => "Lit les dernières Vie De Merde en local";

		public override void Action(string[] parameters)
		{
			string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string path = Path.Combine(applicationData, "FilPasRouge");
			string filename = Path.Combine(path, "viedemerde.json");

			if (File.Exists(filename))
			{
				string json = File.ReadAllText(filename);
				VieDeMerdeCollection collection = Newtonsoft.Json.JsonConvert.DeserializeObject<VieDeMerdeCollection>(json);

				collection.Display(this.Writer);
			}
			else
			{
				this.Writer.WriteLine("Pas de données.");
			}
		}
	}
}
