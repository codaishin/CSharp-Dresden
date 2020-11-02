using System;

namespace CustomProject
{
	enum ConcreteAction
	{
		Nothing = default,
		Attack,
	}

	static class Action
	{
		static Choice[] choices = new Choice[] {
			new Choice{ selector = "n", action = ConcreteAction.Nothing },
			new Choice{ selector = "a", action = ConcreteAction.Attack },
		};

		struct Choice
		{
			public string selector;
			public ConcreteAction action;

			public override string ToString() => $"{this.selector}: {this.action}";
		}

		public static ConcreteAction SelectAction()
		{
			Console.WriteLine("What do you want to do?");
			Console.WriteLine(string.Join(", ", Action.choices));
			switch (Console.ReadLine()) {
				case "a": return ConcreteAction.Attack;
				case "n":
				default: return ConcreteAction.Nothing;
			}
		}
	}
}
