using System;

namespace CustomProject
{
	static class Info
	{
		private static string[] intro = new string[] {
			"",
			"Welcome",
			"",
			"This is a monster fighter game. Each round you are asked for input",
			"- You can decide to attack. Each consecutive attack will reduce your",
			"  overall damage though.",
			"- You can also choose to do nothing, which will reset your full damage",
			"- You can also choose to dodge, which in addition to resetting your",
			"  full damage will also double your evasion for one round.",
			"",
			"Have fun!",
			"",
		};

		private static void AnyKeyContinue()
		{
			Console.Write("Press any key to continue...");
			Console.ReadKey();
			Console.WriteLine("\r                             ");
		}

		public static void Intro()
		{
			Console.WriteLine(string.Join("\n", Info.intro));
			Info.AnyKeyContinue();
		}

		public static void Stats(in GameObject obj)
		{
			string[] stats = new string[] {
				$"{obj.name.ToUpper()}",
				"├─ Defense:",
				$"│  ├─ Hp:       {obj.hp}",
				$"│  └─ Evasion:  {obj.evasion}",
				"└─ Offense:",
				$"   ├─ Damage:   {obj.damage}",
				$"   └─ Accuracy: {obj.accuracy}",
			};
			Console.WriteLine(string.Join("\n", stats));
			Info.AnyKeyContinue();
		}
	}
}
