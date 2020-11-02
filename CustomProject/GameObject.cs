using System;

namespace CustomProject
{
	struct GameObject
	{
		public int hp;
		public int damage;
		public string name;

		public static void Init(out GameObject player, out GameObject monster)
		{
			player = new GameObject { name = "player", hp = 50, damage = 10 };
			monster = new GameObject { name = "monster", hp = 40, damage = 5 };
		}

		public static void Render(params GameObject[] objects)
		{
			foreach (GameObject obj in objects)
			{
				Console.WriteLine($"| {obj.name} hp: {obj.hp} |");
			}
		}

		public static void Attack(in GameObject attkr, ref GameObject trgt)
		{
			Console.WriteLine(
				$"-> {attkr.name}: attacks {trgt.name} for {attkr.damage} damage"
			);
			trgt.hp -= attkr.damage;
		}
	}
}
