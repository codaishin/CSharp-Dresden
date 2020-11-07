using System;
using System.Linq;

namespace BattleShip1PDataDriven
{
	static class Render
	{
		private static string GetFieldContnet(in Field field,
		                                      in bool[,] battleField,
		                                      in Field[][] ships)
		{
			if (battleField[field.x,field.y]) {
				if (Field.HasShip(field, ships)) {
					return "X";
				} else {
					return "~";
				}
			}
			return " ";
		}

		private static string ColumnNumbers(in int size, in string fmt)
		{
			string result = string.Empty;
			for (int i = 1; i <= size; ++i) {
				result += string.Format(fmt, i);
			}
			return result;
		}

		public static void Head(in int sizeX, in int sizeY)
		{
			string prefix = "    ";
			Console.WriteLine($"{prefix}{Render.ColumnNumbers(sizeX, " {0,-2}")}");
			Console.WriteLine($"{prefix}------------------------------");
		}

		public static void BattleField(bool[,] battleField, Field[][] ships)
		{
			int sizeX = battleField.GetLength(0);
			int sizeY = battleField.GetLength(1);

			Render.Head(sizeX, sizeY);
			for (int y = 0; y < sizeY; ++y) {
				Console.Write($"{(char)(65 + y)} | ");
				for (int x  = 0; x < sizeX; ++x) {
					Field field = new Field { x = x, y = y};
					string content = Render.GetFieldContnet(field, battleField, ships);
					Console.Write($"[{content}]");
				}
				Console.WriteLine();
			}
		}

		public static void Hits(in Field[][] ships)
		{
			for (int i = 0; i < ships.Length; ++i) {
				Field[] ship = ships[i];
				int hitCount = ship.Sum(f => f.hit ? 1 : 0);
				Console.WriteLine($"Ship {i + 1}: {hitCount}/{ship.Length}");
			}
		}

		public static void DebugRenderShips(in Field[][] ships)
		{
			foreach (Field[] ship in ships) {
				Console.WriteLine(string.Join(", ", ship));
			}
		}
	}
}
