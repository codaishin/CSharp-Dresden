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
			 while (monster.hp > 0) {
			 	Program.Render(player, monster);
			 	Program.PlayerAttack(player, monster);
			 }
		}
	}
}
