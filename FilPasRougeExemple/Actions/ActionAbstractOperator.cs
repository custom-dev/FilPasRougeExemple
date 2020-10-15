using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	/// <summary>
	/// Les 4 opérateurs Add, Mul, Sub et Div sont très similaire. Le maximum de code
	/// a été factorisé au sein de cette classe abstraite.
	/// </summary>
	public abstract class ActionAbstractOperator : ActionAbstract
	{
		public ActionAbstractOperator(TextWriter writer): base(writer)
		{
		}

		/// <summary>
		/// Réalise l'opération associé à l'opérateur.
		/// </summary>
		/// Cette méthode est protected, car seules les classes
		/// filles ont besoin d'avoir accès à la méthode.
		/// <param name="f1">Premier nombre</param>
		/// <param name="f2">Deuxième nombre</param>
		/// <returns>Résultat de l'opération</returns>
		protected abstract float Compute(float f1, float f2);

		/// <summary>
		/// Cette méthode accepte 2 paramètres de types flottant, au lieu d'un <see cref="string[]"/>.
		/// Les paramètres sont donc plus sécurisés.
		/// 
		/// Voyez-vous l'intérêt d'une implémentation explicite des membres d'une interface ?
		/// L'interface <see cref="IAction"/>, avec sa méthode <see cref="Action(string[])"/> permet
		/// de passer un nombre variable de paramètres. Mais cela peut donc être source d'erreur
		/// lorsqu'on souhaite appeler une instance concrète et non via son interface.
		/// 
		/// Aussi, quand on manipule une instance concrète, on fait tout pour "masquer" le membre
		/// <see cref="IAction.Action(string[])"/> devenu indésirable.
		/// 
		/// En outre, cette cission permet de séparer dans 2 méthodes distinctes l'analyse, la vérification et
		/// la conversion des paramètres dans l'une, et l'exécution de l'action à proprement parler dans une autre.
		/// C'est plus propre !
		/// </summary>
		/// <param name="f1"></param>
		/// <param name="f2"></param>
		public void Action(float f1, float f2)
		{
			float result = this.Compute(f1, f2);
			this.Writer.WriteLine(result);
		}

		/// <summary>
		/// Cette méthode n'est pas l'implémentation du membre <see cref="IAction.Action(string[])"/>, mais 
		/// une implémentation du membre <see cref="ActionAbstract.Action(string[])"/>. La différence est
		/// subtile, et les deux méthodes sont liées (la première appelle la seconde). 
		/// 
		/// Notez la visilité de cette méthode, protégée, qui la rend accessible uniquement au sein de
		/// la classe et de ses dérivées.
		/// 
		/// Cette méthode s'occupe uniquement de traiter les paramètres. Elles vérifient qu'il y en a bien 2 
		/// et les convertie en nombre flottant avant d'appeler la méthode <see cref="Action(float, float)"/>
		/// </summary>
		/// <param name="parameters"></param>
		protected override void Action(string[] parameters)
		{
			if (parameters == null || parameters.Length != 3) { throw new ActionParameterException(ActionParameterException.INVALID_PARAMETER_COUNT); }
			string n1 = parameters[1];
			string n2 = parameters[2];

			float f1 = float.Parse(n1);
			float f2 = float.Parse(n2);

			this.Action(f1, f2);
		}
	}
}
