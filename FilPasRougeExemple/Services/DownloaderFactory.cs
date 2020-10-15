using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExemple.Services
{
	/// <summary>
	/// Implémentation de la factory <see cref="IDownloaderFactory"/>
	/// </summary>
	public class DownloaderFactory : IDownloaderFactory
	{
		/// <summary>
		/// Méthode <see cref="Create"/> qui renvoie un <see cref="Downloader"/>
		/// au lieu d'un <see cref="IDownloader"/>.
		/// </summary>
		/// <remarks>
		/// Pour arriver à cela, on utilise l'implémentation explicite de l'interface.
		/// On implémente donc explicitement <see cref="IDownloaderFactory.Create"/>
		/// afin de pouvoir définir une méthode <see cref="Create"/> tout en changeant son
		/// type de retour.
		/// </remarks>
		/// <returns>Nouvelle instance de <see cref="Downloader"/></returns>
		public Downloader Create()
		{
			return new Downloader();
		}

		/// <summary>
		/// Implémentation explicite de la méthode Create() de l'interface
		/// IDownloaderFactory.
		/// </summary>
		/// <returns>Nouvelle instance de IDownloader</returns>
		IDownloader IDownloaderFactory.Create()
		{
			// Ici, this est de type DownloaderFactory. 
			// Il ne peut donc faire référence à une méthode instanciée explicitement.
			// La méthode Create appelée ici est donc celle définie ci-dessus.
			return this.Create(); 
		}
	}
}
