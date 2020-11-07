using System;
using System.Linq;

namespace BattleShip1PDataDriven
{
	class Program
	{
		static bool HasShip(in (int x, int y) field, in (int x, int y)[][] ships)
		{
			foreach ((int x, int y)[] ship in ships) {
				if (ship.Contains(field)) {
					return true;
				}
			}
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

		static void TryHit(in bool[,] battleField)
		{
			Console.Write("\nAttack field: ");

			string input = Console.ReadLine();
			if (Program.StringToField(input, battleField, out int x, out int y)) {
				battleField[x, y] = true;
			} else {
				Console.WriteLine("Input not understood.");
				Console.Write("Press any key to continue ...");
				Console.ReadKey();
			}
		}

		static void Main(string[] args)
		{
			int size = 10;
			bool[,] battleField = new bool[size,size];
			(int x, int y)[][] ships = new (int, int)[][] {
				new (int, int)[] { (1, 1) },
				new (int, int)[] { (2, 2), (2, 3) },
				new (int, int)[] { (3, 3), (4, 3), (5, 3) },
				new (int, int)[] { (6, 6), (6, 7), (6, 8), (6, 9) },
			};

			while (true) {
				Console.Clear();
				Program.RenderBattleField(battleField, ships);

				Program.TryHit(battleField);
			}
		}
	}
}
