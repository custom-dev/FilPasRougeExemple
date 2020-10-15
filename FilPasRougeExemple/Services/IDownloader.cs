using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExemple.Services
{
	/// <summary>
	/// Interface permettant le téléchargement de ressource sur internet
	/// </summary>
	public interface IDownloader : IDisposable
	{
		/// <summary>
		/// Télécharge la page dont l'url est passée en paramètre et renvoie
		/// le code HTML correspondant.
		/// </summary>
		/// <param name="url">URL de la page</param>
		/// <returns>code HTML de la page</returns>
		string DownloadString(string url);
	}
}
