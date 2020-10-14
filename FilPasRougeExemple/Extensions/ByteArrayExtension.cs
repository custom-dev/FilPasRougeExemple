using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

// Mise en oeuvre d'une méthode d'extension.
// Ici, on rajoute une méthode à un type que
// nous n'avons pas défini (byte[]).
namespace FilPasRougeExemple.Extensions
{
	/// <summary>
	/// Cette classe joute des méthodes d'extension au type byte[].
	/// </summary>
	public static class ByteArrayExtension
	{
		/// <summary>
		/// Convertie un byte[] en représentation hexadécimale.
		/// </summary>
		/// <param name="data">Le tableau à convertir</param>
		/// <returns>représentation hexadécimale sous forme de chaîne de caractères</returns>
		public static string ToHex(this byte[] data)
		{
			if (data == null) { throw new NullReferenceException(); }

			// Lors de la construction d'une chaine de caractères, 
			// il est souvent plus performant d'utiliser un StringBuilder
			// que l'opérateur + (concaténation).
			// En effet, l'opérateur + alloue à chaque fois une nouvelle chaine de caractère
			// et copie les deux parties à concaténer dans une nouvelle chaîne.
			// StringBuilder stocke en interne les différents éléments, et créer ensuite
			// la chaîne finale lors de l'appel à la méthode ToString().
			StringBuilder builder = new StringBuilder();
			foreach (byte b in data )
			{
				builder.Append(b.ToString("x2"));
			}
			
			return builder.ToString();
		}
	}
}
