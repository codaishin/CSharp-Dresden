using System;
using System.Linq;

namespace BattleShip1PDataDriven
{
	class Program
	{
		static bool HasShip(in (int x, int y) field, in (int x, int y)[][] ships)
		{
			return Program.HasShip(field, ships, out _);
		}

		static bool HasShip(in (int x, int y) field,
		                    in (int x, int y)[][] ships,
		                    out int hit)
		{
			for (int i = 0; i < ships.Length; ++i) {
				if (ships[i].Contains(field)) {
					hit = i;
					return true;
				}
			}
			hit = default;
			return false;
		}

		static string Content(in (int x, int y) field,
		                      in bool[,] battleField,
		                      in (int x, int y)[][] ships)
		{
			if (battleField[field.x,field.y]) {
				if (Program.HasShip(field, ships)) {
					return "X";
				} else {
					return "~";
				}
			}
			return " ";
		}

		static string ColumnNumbers(in int size, in string fmt)
		{
			string result = string.Empty;
			for (int i = 1; i <= size; ++i) {
				result += string.Format(fmt, i);
			}
			return result;
		}

		static void RenderHead(in int sizeX, in int sizeY)
		{
			string prefix = "    ";
			Console.WriteLine($"{prefix}{Program.ColumnNumbers(sizeX, " {0,-2}")}");
			Console.WriteLine($"{prefix}------------------------------");
		}

		static void RenderBattleField(bool[,] battleField, (int x, int y)[][] ships)
		{
			int sizeX = battleField.GetLength(0);
			int sizeY = battleField.GetLength(1);

			Program.RenderHead(sizeX, sizeY);
			for (int y = 0; y < sizeY; ++y) {
				Console.Write($"{(char)(65 + y)} | ");
				for (int x  = 0; x < sizeX; ++x) {
					string content = Program.Content((x, y), battleField, ships);
					Console.Write($"[{content}]");
				}
				Console.WriteLine();
			}
		}

		static void RenderHits(in (int x, int y)[][] ships, in int[] hits)
		{
			for (int i = 0; i < hits.Length; ++i) {
				int hitCount = Math.Min(hits[i], ships[i].Length);
				Console.WriteLine($"Ship {i + 1}: {hitCount}/{ships[i].Length}");
			}
		}

		static bool CharToY(in char value, int sizeY, out int y)
		{
			y = value - 65;
			if (y >= 0 && y < sizeY) {
				return true;
			}
			y = value - 97;
			if (y >= 0 && y < sizeY) {
				return true;
			}
			y = default;
			return false;
		}

		static bool StringToField(in string value,
		                          in bool[,] battleField,
		                          out int x, out int y)
		{
			if (Program.CharToY(value[0], battleField.GetLength(1), out y) &&
			    int.TryParse(value.Substring(1), out x) &&
					x > 0 && x <= battleField.GetLength(0)) {
				x -= 1;
				return true;
			}
			x = default;
			y = default;
			return false;
		}

		static void TryHit(in bool[,] battleField,
		                   in (int x, int y)[][] ships,
		                   in int[] hits)
		{
			Console.Write("\nAttack field: ");

			string input = Console.ReadLine();
			if (Program.StringToField(input, battleField, out int x, out int y)) {
				battleField[x, y] = true;
				if (Program.HasShip((x, y), ships, out int hit)) {
					++hits[hit];
				}
			} else {
				Console.WriteLine("Input not understood.");
				Console.Write("Press any key to continue ...");
				Console.ReadKey();
			}
		}

		static bool AnyShipAllive((int x, int y)[][] ships, int[] hits)
		{
			for (int i = 0; i < hits.Length; ++i) {
				if (hits[i] < ships[i].Length) {
					return true;
				}
			}
			return false;
		}

		static void Main(string[] args)
		{
			int size = 10;
			int attacks = 0;
			bool[,] battleField = new bool[size,size];
			(int x, int y)[][] ships = new (int, int)[][] {
				new (int, int)[] { (1, 1) },
				new (int, int)[] { (2, 2), (2, 3) },
				new (int, int)[] { (3, 3), (4, 3), (5, 3) },
				new (int, int)[] { (6, 6), (6, 7), (6, 8), (6, 9) },
			};
			int[] hits = new int[4];

			while (Program.AnyShipAllive(ships, hits)) {
				Console.Clear();
				Program.RenderBattleField(battleField, ships);
				Console.WriteLine("\nShips hit:");
				Program.RenderHits(ships, hits);

				Program.TryHit(battleField, ships, hits);
				++attacks;
			}

			Console.Clear();
			Program.RenderBattleField(battleField, ships);
			Console.WriteLine("\nShips hit:");
			Program.RenderHits(ships, hits);

			Console.WriteLine($"You won with {attacks} attacks");
		}
	}
}
