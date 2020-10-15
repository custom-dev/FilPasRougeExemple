using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.BusinessLayer.VDM
{
	/// <summary>
	/// Représente une collection de vie de merde.
	/// </summary>
	public class VieDeMerdeCollection
	{
		/// <summary>
		/// Tableau des Vie de merde
		/// </summary>
		public VieDeMerde[] VieDemerde { get; set; }

		/// <summary>
		/// Nombre de vie de merde dans la collection
		/// </summary>
		public int Count => this.VieDemerde?.Length ?? 0;

		/// <summary>
		/// Affiche les Vie de merde via le <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">Writer à utiliser pour l'affichage des VDM</param>
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
