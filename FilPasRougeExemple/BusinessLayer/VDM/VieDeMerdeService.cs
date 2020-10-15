using FilPasRougeExemple.Services;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace FilPasRougeExemple.BusinessLayer.VDM
{
	/// <summary>
	/// Classe faisant la liaison avec le site Vie de merde
	/// </summary>
	public class VieDeMerdeService
	{
		/// <summary>
		/// URL du site viedemerde
		/// </summary>
		private static readonly string _url = "https://www.viedemerde.fr";

		/// <summary>
		/// Factory permettant de créer des objets gérant le téléchargement d'information depuis
		/// le net.
		/// </summary>
		private IDownloaderFactory _downloaderFactory;

		/// <summary>
		/// Constructeur par défaut.
		/// 
		/// Ce constructeur injecte automatiquement les dépendances qui lui sont nécessaires.
		/// </summary>
		public VieDeMerdeService() : this(new DownloaderFactory())
		{

		}

		/// <summary>
		/// Constructeur paramétrable.
		/// 
		/// Chaque dépendance peut être passée en tant que paramètre. Cela permet d'injecter
		/// les dépendances à la construction de l'objet. Utile pour les tests unitaires.
		/// </summary>
		/// <param name="downloaderFactory"></param>
		public VieDeMerdeService(IDownloaderFactory downloaderFactory)
		{
			_downloaderFactory = downloaderFactory;
		}

		/// <summary>
		/// Récupération des dernières VDM.
		/// </summary>
		/// <returns>Collection de VDM</returns>
		public VieDeMerdeCollection GetLastVieDeMerdes()
		{
			VieDeMerdeCollection vdms = new VieDeMerdeCollection();
			List<VieDeMerde> list = new List<VieDeMerde>();

			using (IDownloader downloader = _downloaderFactory.Create())
			{
				string html = downloader.DownloadString(_url);
				HtmlDocument doc = new HtmlDocument();
				doc.LoadHtml(html);

				HtmlNodeCollection articles = doc.DocumentNode.SelectNodes("//article[@class='article-panel']");

				foreach (HtmlNode article in articles)
				{
					VieDeMerde vdm = new VieDeMerde();
					vdm.Titre = ExtractTitre(article);
					vdm.Auteur = ExtractAuteur(article);
					vdm.Contenu = ExtractContent(article);
					list.Add(vdm);
				}
			}

			vdms.VieDemerde = list.ToArray();
			return vdms;
		}
		
		/// <summary>
		/// Extrait le titre d'une VDM
		/// </summary>
		/// <param name="article">Noeud HTML représentant la VDM</param>
		/// <returns>Titre de la VDM</returns>
		private static string ExtractTitre(HtmlNode article)
		{
			HtmlNode titreNode = article.SelectSingleNode(".//h2");
			return HttpUtility.HtmlDecode(titreNode.InnerText);
		}

		/// <summary>
		/// Extrait l'auteur d'une VDM
		/// </summary>
		/// <param name="article">Noeud HTML représentant la VDM</param>
		/// <returns>Auteur de la VDM</returns>
		private static string ExtractAuteur(HtmlNode article)
		{
			HtmlNode auteurNode = article.QuerySelector("div.article-topbar");
			string auteur = auteurNode.InnerText;
			string[] parts = auteur.Split("\n", StringSplitOptions.RemoveEmptyEntries);

			auteur = parts[1];

			return HttpUtility.HtmlDecode(auteur);
		}

		/// <summary>
		/// Extrait le contenu d'une VDM
		/// </summary>
		/// <param name="article">Noeud HTML représentant la VDM</param>
		/// <returns>Contenu de la VDM</returns>
		private static string ExtractContent(HtmlNode article)
		{
			HtmlNode contentNode = article.SelectSingleNode(".//a[@class='article-link']");
			HtmlNode titreNode = contentNode.SelectSingleNode("h2");
			HtmlNode c=titreNode.NextSibling;
			return HttpUtility.HtmlDecode(c.InnerText);
		}	
	}
}
