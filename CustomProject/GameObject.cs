using System;

namespace CustomProject
{
	struct GameObject
	{
		private static Random rand = new Random();

		public string name;

		public int hp;
		public int damage;
		public int evasion;
		public int accuracy;
		public bool dodging;

		public static void Init(out GameObject player, out GameObject monster)
		{
			player = new GameObject {
				name = "player",
				hp = 50,
				damage = 10,
				accuracy = 50,
				evasion = 80,
			};
			monster = new GameObject {
				name = "monster",
				hp = 40,
				damage = 5,
				accuracy = 100,
				evasion = 10,
			};
		}

		public static void Render(params GameObject[] objects)
		{
			foreach (GameObject obj in objects)
			{
				Console.WriteLine($"| {obj.name} hp: {obj.hp} |");
			}
		}

		public static void Attack(ref GameObject attkr, ref GameObject trgt)
		{
			Console.WriteLine($"-> {attkr.name}: attacks {trgt.name}");
			attkr.dodging = false;
			if (GameObject.Hit(attkr, trgt)) {
				trgt.hp -= attkr.damage;
				Console.WriteLine($"-> {attkr.damage} damage");
			} else {
				Console.WriteLine("-> MISS!");
			}
		}

		private static bool Hit(in GameObject attkr, in GameObject trgt)
		{
			int hitMax = attkr.accuracy + trgt.evasion + 1;
			return GameObject.rand.Next(0, hitMax) > trgt.evasion;
		}

		public static void Dodge(ref GameObject dodger)
		{
			Console.WriteLine($"-> {dodger.name}: prepares to dodge");
			dodger.dodging = true;
		}
	}
}
