using System;

namespace CustomProject
{
	struct GameObject
	{
		private static Random rand = new Random();

		// Name
		public string name;

		// Stats
		public int hp;
		public int damage;
		public int evasion;
		public int accuracy;

		// Set in game loop
		public bool dodging;
		public int consecutiveAttacks;  // consecutive attacks weaken outgoing damage

		public static void Init(out GameObject player, out GameObject monster)
		{
			player = new GameObject {
				name = "player",
				hp = 50,
				damage = 10,
				accuracy = 50,
				evasion = 60,
			};
			monster = new GameObject {
				name = "monster",
				hp = 60,
				damage = 15,
				accuracy = 60,
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
			if (GameObject.Hit(attkr, trgt)) {
				int dmg = Math.Max(attkr.damage - attkr.consecutiveAttacks, 1);
				trgt.hp -= dmg;
				Console.WriteLine($"-> {dmg} damage");
			} else if (trgt.dodging) {
				Console.WriteLine($"-> DODGED!");
			} else {
				Console.WriteLine($"-> MISS!");
			}
			attkr.dodging = false;
			++attkr.consecutiveAttacks;
		}

		private static bool Hit(in GameObject attkr, in GameObject trgt)
		{
			int evasion = trgt.dodging ? trgt.evasion * 2 : trgt.evasion;
			int hitMax = attkr.accuracy + evasion + 1;
			int hit = GameObject.rand.Next(0, hitMax);
			return hit > evasion;
		}

		public static void Dodge(ref GameObject dodger)
		{
			Console.WriteLine($"-> {dodger.name}: prepares to dodge");
			dodger.dodging = true;
			dodger.consecutiveAttacks = 0;
		}

		public static void Idle(ref GameObject obj)
		{
			Console.WriteLine($"-> {obj.name}: does nothing");
			obj.dodging = false;
			obj.consecutiveAttacks = 0;
		}
	}
}
