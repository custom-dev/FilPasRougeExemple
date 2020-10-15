using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExemple.Services
{
	/// <summary>
	/// Interface définissant des interactions avec le système de
	/// fichier
	/// </summary>
	public interface IFileSystem
	{
		/// <summary>
		/// Vérifie si le fichier passé en paramètre existe
		/// </summary>
		/// <param name="filename">Chemin du fichier. Peut-être relatif au répartoire courant ou absolu</param>
		/// <returns>true si le fichier existe, false sinon</returns>
		/// <exception cref="ArgumentNullException">Si le nom de fichier est null ou vide</exception>
		bool Exists(string filename);

		/// <summary>
		/// Crée une arborescence. Chaque répertoire du chemin passé
		/// en paramètre est créé si besoin est.
		/// 
		/// Si tous les répertoire existe déjà, cette méthode ne fait rien.
		/// </summary>
		/// <param name="path">Chemin du répertoire à créer</param>
		/// <exception cref="ArgumentNullException">Si le chemin est null ou vide</exception>
		void CreateDirectory(string path);

		/// <summary>
		/// Retourne le contenu d'un fichier sous forme de texte.
		/// </summary>
		/// <param name="filename">Chemin du fichier à lire</param>
		/// <returns>contenu du fichier sous forme de <see cref="string"/></returns>
		/// <exception cref="ArgumentNullException">Si le nom de fichier est null ou vide</exception>
		string ReadAllText(string filename);

		/// <summary>
		/// Retourne le contenu d'un fichier sous forme binaire.
		/// </summary>
		/// <param name="filename">Chemin du fichier à lire</param>
		/// <returns>Contenu du fichier, sous forme de byte[]</returns>
		/// <exception cref="ArgumentNullException">Si le nom de fichier est null ou vide</exception>
		byte[] ReadAllBytes(string filename);

		/// <summary>
		/// Ecrit le contenu textuel dans le fichier spécifié.
		/// 
		/// Le fichier est créé s'il n'existe pas.
		/// </summary>
		/// <param name="filename">Chemin du fichier</param>
		/// <param name="content">Contenu à enregistrer</param>
		/// <exception cref="ArgumentNullException">Si le nom de fichier est null ou vide</exception>
		void WriteAllText(string filename, string content);

		/// <summary>
		/// Ecrit le contenu binaire dans le fichier spécifié.
		/// </summary>
		/// <param name="filename">Chemin du fichier</param>
		/// <param name="data">Contenu binaire à enregistrer</param>
		/// <exception cref="ArgumentNullException">Si le nom de fichier est null ou vide</exception>
		void WriteAllBytes(string filename, byte[] data);

	}
}
