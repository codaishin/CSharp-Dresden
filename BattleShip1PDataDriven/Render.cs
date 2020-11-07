using System;
using System.Collections.Generic;
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

		private static IEnumerable<string> Head(int sizeX, int sizeY)
		{
			string prefix = "    ";
			yield return $"{prefix}{Render.ColumnNumbers(sizeX, " {0,-2}")}";
			yield return $"{prefix}------------------------------";
		}

		private static
		string WorldHorizontal(bool[,] world, int y, int sizeX, Field[][] ships)
		{
			string result = $"{(char)(65 + y)} | ";
			for (int x  = 0; x < sizeX; ++x) {
				Field field = new Field { x = x, y = y};
				string content = Render.GetFieldContnet(field, world, ships);
				result += $"[{content}]";
			}
			return result;
		}

		public static IEnumerable<string> World(bool[,] world, Field[][] ships)
		{
			int sizeX = world.GetLength(0);
			int sizeY = world.GetLength(1);

			foreach (string line in Render.Head(sizeX, sizeY)) {
				yield return line;
			}
			for (int y = 0; y < sizeY; ++y) {
				yield return Render.WorldHorizontal(world, y, sizeX, ships);
			}
		}

		public static IEnumerable<string> Hits(Field[][] ships)
		{
			for (int i = 0; i < ships.Length; ++i) {
				Field[] ship = ships[i];
				int hitCount = ship.Sum(f => f.hit ? 1 : 0);
				yield return $"Ship {i + 1}: {hitCount}/{ship.Length}";
			}
		}

		public static IEnumerable<string> DebugRenderShips(Field[][] ships)
		{
			foreach (Field[] ship in ships) {
				yield return string.Join(", ", ship);
			}
		}
	}
}
