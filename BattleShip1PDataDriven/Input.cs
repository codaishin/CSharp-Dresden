using System;

namespace BattleShip1PDataDriven
{
	static class Input
	{
		private static bool CharToNum(in char value, int sizeY, out int y)
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

		public static bool StringToField(in string value,
		                                 in bool[,] battleField,
		                                 out Field field)
		{
			int x, y;
			if (Input.CharToNum(value[0], battleField.GetLength(1), out y) &&
			    int.TryParse(value.Substring(1), out x) &&
					x > 0 && x <= battleField.GetLength(0)) {
				x -= 1;
				field = new Field{ x = x, y = y };
				return true;
			}
			field = default;
			return false;
		}
	}
}
