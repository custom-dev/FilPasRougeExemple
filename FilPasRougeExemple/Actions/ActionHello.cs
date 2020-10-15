using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	/// <summary>
	/// Action Hello.
	/// 
	/// Ne fait rien d'autre qu'afficher "Hello World !"
	/// </summary>
	public class ActionHello : ActionAbstract
	{
		#region Injection de dépendance
		/// <summary>
		/// On gère ici l'injection de dépendance via le constructeur.
		/// </summary>
		/// <param name="writer"></param>
		public ActionHello(TextWriter writer): base(writer) { }
		#endregion

		#region Implémentation de IAction
		public override string Name => "Hello";

		public override string Description => "Affiche 'Hello World'";
		#endregion

		/// <summary>
		/// Méthode a appeler pour exécuter l'action.
		/// 
		/// Notez qu'elle ne prend pas de paramètre. 
		/// On a tout fait pour "masquer" le membre <see cref="IAction.Action(string[])"/> (en
		/// utilisant une implémentation explicite) car trop "générique".
		/// </summary>
		public void Action()
		{
			this.Writer.WriteLine("Hello World");
		}

		/// <summary>
		/// Cette méthode n'est pas l'implémentation du membre <see cref="IAction.Action(string[])"/>, mais 
		/// une implémentation du membre <see cref="ActionAbstract.Action(string[])"/>. La différence est
		/// subtile, et les deux méthodes sont liées (la première appelle la seconde). 
		/// 
		/// Notez la visilité de cette méthode, protégée, qui la rend accessible uniquement au sein de
		/// la classe et de ses dérivées.
		/// </summary>
		/// <param name="parameters"></param>
		protected override void Action(string[] parameters)
		{
			if (parameters != null && parameters.Length != 1) { throw new ActionParameterException(ActionParameterException.INVALID_PARAMETER_COUNT); }

			this.Action();
		}
	}
}
