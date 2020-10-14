using FilPasRougeExemple.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExempleTests.Actions
{
	[TestClass]
	public class ActionManagerTest
	{
		[TestMethod]
		public void GetActions()
		{
			// arrange

			// act
			IReadOnlyCollection<IAction> actions = ActionManager.Instance.GetActions();

			// assert
			Assert.IsTrue(actions.Count > 0);
			foreach(IAction action in actions)
			{
				Assert.IsNotNull(action);
			}
		}

		[TestMethod]
		public void GetSpecificAction()
		{
			// arrange
			//act
			IAction action = ActionManager.Instance.GetAction("Hello");

			// Assert
			Assert.IsNotNull(action);
			Assert.AreEqual("Hello", action.Name);
		}
	}
}
