using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	/// <summary>
	/// Classe de base pour toutes les actions.
	/// 
	/// Cette classe utilise l'injection de dépendance à la construction
	/// afin de préciser le <see cref="TextWriter"/> à utiliser pour les sorties.
	/// 
	/// Comme on implémente <see cref="IAction"/>, on est obligé de définir les propriété 
	/// <see cref="Name"/> et <see cref="Description"/>.
	/// Toutefois, comme ces propriétés sont destinées a être implémentées dans une classe dérivée
	/// on marque les propriétés comme <c>abstract</c>
	/// </summary>
	public abstract class ActionAbstract : IAction
	{
		#region Injection de dépendance
		/// <summary>
		/// Constructeur avec injection de dépendance.
		/// 
		/// La classe <see cref="ActionAbstract"/> dépend d'un <see cref="TextWriter"/>
		/// qui est tout simplement passé en paramètre du constructeur.
		/// </summary>
		/// <param name="writer"></param>
		protected ActionAbstract(TextWriter writer)
		{
			Writer = writer;
		}

		/// <summary>
		/// <see cref="TextWriter"/> utilisé pour écrire des données.
		/// 
		/// Il est marqué comme <c>protected</c> car seule les classes dérivants
		/// de <see cref="ActionAbstract"/> sont amenées à l'utiliser.
		/// </summary>
		protected TextWriter Writer { get; }
		#endregion

		#region Implémentation de IAction

		public abstract string Name { get; }

		public abstract string Description { get; }

		/// <summary>
		/// Cette méthode est implémentée explicitement. Autrement dit,
		/// elle n'est utilisable que si l'objet sur lequel on l'appelle
		/// est de type <see cref="IAction"/>. Si c'est un objet de type 
		/// <see cref="ActionAbstract"/> ou d'un type dérivé, la méthode ne sera 
		/// pas disponible.
		/// 
		/// Cela permet de masquer cette fonction dont la signature est trop
		/// "générique" pour privilégier la méthode avec une signature parlante.
		/// </summary>
		/// <param name="parameters"></param>
		void IAction.Action(string[] parameters)
		{
			this.Action(parameters);
		}
		#endregion

		/// <summary>
		/// Méthode appelée lorsqu'on utilise la méthode explicite
		/// <see cref="IAction.Action(string[])"/>.
		/// 
		/// Cela permet de redéfinir cette méthode dans les sous-classes,
		/// car il n'est malheureusement pas possible d'implémenter une méthode
		/// d'une interface explicitement tout en la marquant comme <c>abstract</c>.
		/// 
		/// Le code suivant est invalide !
		/// <code>
		/// abstract void IAction.Action(string[] parameters);
		/// </code>
		/// </summary>
		/// <param name="parameters"></param>
		protected abstract void Action(string[] parameters);

	
	}
}
