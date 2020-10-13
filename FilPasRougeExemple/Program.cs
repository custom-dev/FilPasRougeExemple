using FilPasRougeExemple.Actions;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace FilPasRougeExemple
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				ShowHelp();
			}
			else
			{
				string actionName = args[0];
				IAction action = ActionManager.Instance.GetAction(actionName);

				if (action != null)
				{
					action.Action(args);
				}
				else
				{
					Console.WriteLine("Commande inconnue");
				}
			}
		}

		private static void ShowHelp()
		{
			IReadOnlyCollection<IAction> actions = ActionManager.Instance.GetActions();

			Console.WriteLine("Aide de FilPasRouge");
			Console.WriteLine("-------------------");
			
			foreach(IAction action in actions)
			{
				Console.WriteLine($"{action.Name} : {action.Description}");
			}
		}		
	}
}
