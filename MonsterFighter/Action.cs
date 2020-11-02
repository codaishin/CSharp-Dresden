using System;
using System.Collections.Generic;

namespace MonsterFighter
{
	enum ConcreteAction
	{
		Nothing = default,
		Attack,
		Dodge,
	}

	static class Action
	{
		static Dictionary<string, ConcreteAction> choices
			= new Dictionary<string, ConcreteAction>() {
				{ "n", ConcreteAction.Nothing },
				{ "a", ConcreteAction.Attack },
				{ "d", ConcreteAction.Dodge },
			};

		public static ConcreteAction SelectAction()
		{
			Console.WriteLine("What do you want to do?");
			Console.WriteLine(string.Join(", ", Action.choices));

			string input = Console.ReadLine();
			if (Action.choices.TryGetValue(input, out ConcreteAction action)) {
				return action;
			}
			return default;
		}
	}
}
