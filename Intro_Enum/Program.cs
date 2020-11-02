using System;

namespace Enum
{
	class Program
	{
		enum Gender { Male, Female, Other }

		enum BookType { Fiction, Scientific }

		enum Direction
		{
			North,
			South,
			East,
			West,
		}

		static string DirectionToString(Direction dir)
		{
			switch (dir) {
				case Direction.North: return "Norden";
				case Direction.South: return "Süden";
				case Direction.East: return "Osten";
				case Direction.West: return "Westen";
			}
			return default;
		}

		static void Main(string[] args)
		{
			Console.WriteLine(Program.DirectionToString(Direction.West));
		}
	}
}
