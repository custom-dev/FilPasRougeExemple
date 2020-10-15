using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	/// <summary>
	/// Classe représentant une action exécutable par l'utilisateur.
	/// </summary>
	public interface IAction
	{
		/// <summary>
		/// Nom de l'action
		/// </summary>
		/// Le nom de l'action sera utilisé pour identifier l'action en tant que paramètre du programme
		string Name { get; }

		/// <summary>
		/// Description de l'action
		/// </summary>
		/// La description de l'action apparait au sein de l'aide
		string Description { get; }

		/// <summary>
		/// Méthode exécutant l'action.
		/// </summary>
		/// <param name="parameters">les paramètres passés au programme (y compris le nom de l'action)</param>
		void Action(string[] parameters);
	}
}
