using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExemple.BusinessLayer.VDM
{
	/// <summary>
	/// Représente une vie de merde
	/// </summary>
	public class VieDeMerde
	{
		/// <summary>
		/// Titre de la VDM
		/// </summary>
		public string Titre { get; set; }

		/// <summary>
		/// Auteur de la VDM
		/// </summary>
		public string Auteur { get; set; }

		/// <summary>
		/// Contenu de la VDM
		/// </summary>
		public string Contenu { get; set; }

		/// <summary>
		/// Nombre de "Je valide, c'est une vie de merde"
		/// </summary>
		public int NbJeValide { get; set; }

		/// <summary>
		/// Nombre de "Tu l'as bien mérité"
		/// </summary>
		public int NbTLBM { get; set; }
	}
}
