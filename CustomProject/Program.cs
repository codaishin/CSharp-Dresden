using System;
using System.Threading;

namespace CustomProject
{
	enum Action
	{
		Nothing = default,
		Attack,
	}

	struct GameObject
	{
		public int hp;
		public int damage;
		public string name;
	}

	struct Option
	{
		public string selector;
		public Action action;

    public override string ToString() => $"{this.selector}: {this.action}";
	}

	class Program
	{
		static Option[] options = new Option[] {
			new Option{ selector = "n", action = Action.Nothing },
			new Option{ selector = "a", action = Action.Attack },
		};

		static void Render(params GameObject[] objects)
		{
			foreach (GameObject obj in objects)
			{
				Console.WriteLine($"| {obj.name} hp: {obj.hp} |");
			}
		}

		static void Attack(in GameObject attkr, ref GameObject trgt)
		{
			Console.WriteLine(
				$"-> {attkr.name}: attacks {trgt.name} for {attkr.damage} damage"
			);
			trgt.hp -= attkr.damage;
		}

		static Action SelectAction()
		{
			Console.WriteLine("What do you want to do?");
			Console.WriteLine(string.Join(", ", options));
			switch (Console.ReadLine()) {
				case "a": return Action.Attack;
				case "n":
				default: return Action.Nothing;
			}
		}

		static void Init(out GameObject player, out GameObject monster)
		{
			player = new GameObject { name = "player", hp = 50, damage = 10 };
			monster = new GameObject { name = "monster", hp = 40, damage = 5 };
		}

		static void Main(string[] args)
		{
			bool playerTurn = true;
			Program.Init(out GameObject player, out GameObject monster);

			while (monster.hp > 0 && player.hp > 0)
			{
				Program.Render(player, monster);
				if (playerTurn) {
					switch (Program.SelectAction()) {
						case Action.Attack: Program.Attack(player, ref monster); break;
					}
				} else {
					Program.Attack(monster, ref player);
				}
				playerTurn = !playerTurn;
				Thread.Sleep(1000);
			}

			if (monster.hp <= 0) {
				Console.WriteLine("You won");
			} else {
				Console.WriteLine("You lost");
			}
		}
  }
}
