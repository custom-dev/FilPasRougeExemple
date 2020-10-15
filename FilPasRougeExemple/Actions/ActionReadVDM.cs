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
	public class ActionReadVDM : ActionAbstractFileSystem
	{		
		public ActionReadVDM(TextWriter writer, IFileSystem fileSystem) : base(writer, fileSystem)
		{
		}

		public override string Name => "ReadVDM";

		public override string Description => "Lit les dernières Vie De Merde en local";

		public void Action()
		{
			string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string path = Path.Combine(applicationData, "FilPasRouge");
			string filename = Path.Combine(path, "viedemerde.json");

			if (this.FileSystem.Exists(filename))
			{
				string json = this.FileSystem.ReadAllText(filename);
				VieDeMerdeCollection collection = Newtonsoft.Json.JsonConvert.DeserializeObject<VieDeMerdeCollection>(json);

				collection.Display(this.Writer);
			}
			else
			{
				this.Writer.WriteLine("Pas de données.");
			}
		}

		protected override void Action(string[] parameters)
		{
			if (parameters == null || parameters.Length != 1) { throw new ActionParameterException(ActionParameterException.INVALID_PARAMETER_COUNT); }

			this.Action();
		}
	}
}
