using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.BusinessLayer.VDM
{
	public class VieDeMerdeCollection
	{
		public VieDeMerde[] VieDemerde { get; set; }

		public void Display(TextWriter writer)
		{
			if (this.VieDemerde == null)
			{
				writer.WriteLine("Pas de vie de merde disponible");
			}
			else
			{
				foreach (VieDeMerde vdm in this.VieDemerde)
				{
					writer.WriteLine($"Titre: {vdm.Titre}");
					writer.WriteLine($"Auteur: {vdm.Auteur}");
					writer.WriteLine(vdm.Contenu);
					writer.WriteLine();
				}
			}
		}
	}
}
