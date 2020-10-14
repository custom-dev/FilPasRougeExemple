using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FilPasRougeExemple.Services
{
	// Imaginons que nous ayons d'un côté une interface (disons IDownloader)
	// et de l'autre côté une classe (disons WebClient) qui implémente
	// les méthodes et propriétés définies au sein de l'interface.
	//
	// Seulement voilà, la classe n'hérite pas de l'interface, et on ne peut 
	// donc pas utiliser une instance de cette classe via cette interface.
	//
	// Comment faire ?
	//
	// Réponse : en utilisant l'héritage !
	// Ici, la classe DownloaderService hérite de WebClient (donc hérite de tous
	// ses membres) et hérite de l'interface (donc doit définir ses membres).
	// La classe DownloaderService répond donc à notre problème ! On a "rajouté"
	// une interface à notre classe de base.
	public class DownloaderService : WebClient, IDownloader
	{	
	
	}
}
