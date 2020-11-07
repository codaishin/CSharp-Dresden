using System.Linq;

namespace BattleShip1PDataDriven
{
	struct Field
	{
		public int x;
		public int y;

		public override string ToString() => $"{(char)(this.y + 65)}{this.x + 1}";

		public static bool HasShip(in Field field, in Field[][] ships)
		{
			return Field.HasShip(field, ships, out _);
		}

		public static bool HasShip(in Field field,
		                           in Field[][] ships,
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
