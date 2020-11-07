using System.Linq;

namespace BattleShip1PDataDriven
{
	static class Field
	{
		public static bool HasShip(in (int x, int y) field, in (int x, int y)[][] ships)
		{
			return Field.HasShip(field, ships, out _);
		}

		public static bool HasShip(in (int x, int y) field,
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
	}
}
