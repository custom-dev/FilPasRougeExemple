using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilPasRougeExemple.Actions
{
	/// <summary>
	/// Exemple de mise en place d'un singleton :
	/// - utilisation d'un attribut de classe (static !)
	/// - utilisation d'un constructeur statique
	/// 
	/// Un constructeur static ne prend pas de paramètre, n'est pas appelable directement
	/// (il n'a donc pas de visibilité).
	/// 
	/// Le constructeur static est automatiquement appelé par le runtime lors de la première
	/// utilisation du type.
	/// 
	/// L'appel au constructeur static est thread-safe.
	/// </summary>
	public class ActionManager
	{
		private static ActionManager _manager;
		private readonly Dictionary<string, IAction> _actions;

		/// <summary>
		/// Initialise le singleton
		/// </summary>
		static ActionManager()
		{
			_manager = new ActionManager();
		}

		private ActionManager()
		{
			IReadOnlyCollection<Type> actions = RetrieveActions();
			IReadOnlyCollection<IAction> implementations = InstantiateActions(actions);
			_actions = implementations.ToDictionary(x => x.Name, x => x);
		}	

		public static ActionManager Instance
		{
			get { return _manager; }
		}

		/// <summary>
		/// Récupère une action par son nom
		/// </summary>
		/// <param name="name">Nom de l'action</param>
		/// <returns>Objet IAction si trouvé, null sinon</returns>
		public IAction GetAction(string name)
		{
			if (_actions.ContainsKey(name))
			{
				return _actions[name];
			}
			else
			{
				return null;
			}
		}

		public IReadOnlyCollection<IAction> GetActions()
		{
			return _actions.Values.ToArray();
		}

		/// <summary>
		/// Retourne la liste des actions, c'est-à-dire des classes
		/// implémentants l'interface IAction
		/// </summary>
		/// Pour arriver à cela, nous allons utiliser la réflexivité du langage,
		/// et parcourir l'ensemble des types disponibles, à la recherche de ceux qui sont
		/// - des classes
		/// - concrètes
		/// - implémentant IAction
		/// <returns>La liste des types implémentant l'interface IAction</returns>
		private static IReadOnlyCollection<Type> RetrieveActions()
		{
			Type wantedInterface = typeof(IAction);

			// On utilise un peu de linq, avec le chaînage des méthodes.
			Type[] types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => wantedInterface.IsAssignableFrom(p) && p.IsClass)
				.ToArray();

			return types;
		}

		private static IReadOnlyCollection<IAction> InstantiateActions(IEnumerable<Type> actionTypes)
		{
			List<IAction> list = new List<IAction>();
			ServiceProvider serviceProvider = new ServiceProvider();

			if (actionTypes != null)
			{
				foreach(Type actionType in actionTypes)
				{
					IAction action = ActivatorUtilities.CreateInstance(serviceProvider, actionType) as IAction;
					list.Add(action);
				}
			}

			return list;
		}
	}
}
