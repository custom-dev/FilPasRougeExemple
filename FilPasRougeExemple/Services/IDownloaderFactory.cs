using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExemple.Services
{
	/// <summary>
	/// Mise en place du design pattern Factory.
	/// 
	/// Classiquement, le nom de l'interface se compose ainsi :
	/// <list type="bullet">
	///   <item>le nom de l'interface à générer (ici, <see cref="IDownloader" />)</item>
	///   <item>le suffixe "Factory"</item>
	/// </list>
	/// </summary>
	public interface IDownloaderFactory
	{
		/// <summary>
		/// Instancie un nouveau <see cref="IDownloader" />
		/// </summary>
		/// <returns></returns>
		IDownloader Create();
	}
}
