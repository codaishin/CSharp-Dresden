using System;

namespace DefaultParameters
{
	class Program
	{
		static void Greet(string grter, string grting = "Hello", string grtee = "World")
		{
			Console.Write(grter);
			Console.Write(": ");
			Console.Write(grting);
			Console.Write(", ");
			Console.WriteLine(grtee);
		}

		static bool GetInput(out int parsed, int maxReTries = 0)
		{
			int tries = 0;
			do {
				if (int.TryParse(Console.ReadLine(), out parsed)) {
					return true;
				}
				++tries;
			} while (tries <= maxReTries);
			return false;
		}

		static void Main(string[] args)
		{
			Program.Greet("Mike");
			Program.Greet("Mike", "Hi");
			Program.Greet("Mike", "Hi", "Students");
			Program.Greet("Mike", grtee: "Students");

			bool success = Program.GetInput(out int parsed, 2);
			Console.WriteLine((success, parsed));
		}
	}
}
