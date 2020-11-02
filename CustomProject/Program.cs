using System;
using System.Collections.Generic;

namespace CustomProject
{
	class Monster
	{
		public int hp;
	}

	class Player
	{
		public int damage;
	}

	enum PlayerType
	{
		Fighter,
		Mage,
	}

	class Program
	{
		static void Render(in Player player, in Monster monster)
		{
			Console.WriteLine($"Monster hp: {monster.hp}");
		}

		static void PlayerAttack(in Player player, in Monster monster)
		{
			Console.WriteLine("Do you want to attack? (y|n)");
			if (Console.ReadLine() == "y") {
				monster.hp -= player.damage;
			}
		}

		static void Main(string[] args)
		{
			Player player = new Player { damage = 10 };
			Monster monster = new Monster { hp = 40 };
			// while (monster.hp > 0) {
			// 	Program.Render(player, monster);
			// 	Program.PlayerAttack(player, monster);
			// }

			Dictionary<PlayerType, int> dict = new Dictionary<PlayerType, int> {
				{ PlayerType.Fighter, 40 },
				{ PlayerType.Mage, 6 },
			};

			foreach (KeyValuePair<PlayerType, int> kvp in dict) {
				Console.WriteLine(((int)kvp.Key + 1, kvp.Key, kvp.Value));
			}
			string input = Console.ReadLine();
			int.TryParse(input, out int parsed);
			PlayerType selected = (PlayerType)(parsed - 1);
			Console.WriteLine(("selected", selected, dict[selected]));
		}
	}
}
