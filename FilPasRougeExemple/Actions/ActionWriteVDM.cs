using FilPasRougeExemple.BusinessLayer.VDM;
using FilPasRougeExemple.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	public class ActionWriteVDM : ActionAbstractFileSystem
	{
		public ActionWriteVDM(TextWriter writer, IFileSystem fileSystem) : base(writer, fileSystem)
		{
		}

		public override string Name => "WriteVDM";

		public override string Description => "Enregistre les dernières Vie De Merde en local";

		public void Action()
		{
			VieDeMerdeService query = new VieDeMerdeService();
			VieDeMerdeCollection collection = query.GetLastVieDeMerdes();

			string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string path = Path.Combine(applicationData, "FilPasRouge");
			string filename = Path.Combine(path, "viedemerde.json");
			this.FileSystem.CreateDirectory(path);
			string json = Newtonsoft.Json.JsonConvert.SerializeObject(collection);
			this.FileSystem.WriteAllText(filename, json);
		}

		protected override void Action(string[] parameters)
		{
			if (parameters == null || parameters.Length != 2) { throw new ActionParameterException(); }

			this.Action();
		}
	}
}
