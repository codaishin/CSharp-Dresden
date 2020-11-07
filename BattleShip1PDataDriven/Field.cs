using System.Linq;

namespace BattleShip1PDataDriven
{
	struct Field
	{
		public int x;
		public int y;
		public bool hit;

		public override string ToString() => $"{(char)(this.y + 65)}{this.x + 1}";

		public static bool HasShip(in Field field, in Field[][] ships)
		{
			return Field.HasShip(field, ships, out _, out _);
		}

		public static bool HasShip(in Field field,
		                           in Field[][] ships,
                               out Field[] ship,
		                           out int fieldIndex)
		{
			for (int i = 0; i < ships.Length; ++i) {
				for (int j = 0; j < ships[i].Length; ++j) {
					ship = ships[i];
					if (ship[j].x == field.x && ship[j].y == field.y) {
						fieldIndex = j;
						return true;
					}
				}
			}
			fieldIndex = default;
			ship = default;
			return false;
		}
	}
}
