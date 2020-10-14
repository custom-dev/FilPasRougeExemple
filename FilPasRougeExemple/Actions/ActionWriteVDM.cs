using FilPasRougeExemple.BusinessLayer.VDM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionWriteVDM : ActionAbstract
	{
		public ActionWriteVDM(TextWriter writer) : base(writer)
		{
		}

		public override string Name => "WriteVDM";

		public override string Description => "Enregistre les dernières Vie De Merde en local";

		public override void Action(string[] parameters)
		{
			VieDeMerdeQuery query = new VieDeMerdeQuery();
			VieDeMerdeCollection collection = query.GetLastVieDeMerdes();

			string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string path = Path.Combine(applicationData, "FilPasRouge");
			string filename = Path.Combine(path, "viedemerde.json");
			Directory.CreateDirectory(path);
			string json = Newtonsoft.Json.JsonConvert.SerializeObject(collection);
			File.WriteAllText(filename, json);
		}
	}
}
