using System;
using System.Linq;
using System.Collections.Generic;

namespace BattleShip1PDataDriven
{
	static class Ship
	{
		private static Random rand = new Random();

		private static Func<Field, Field> VerticalOrHorizontalAdvance()
		{
			if (Ship.rand.Next(0, 2) == 0) {
				return Field.GetNextHorizontal;
			}
			return Field.GetNextVertical;
		}

		private static
		IEnumerable<Field> CreateOn(Field start)
		{
			Field field = start;
			Func<Field, Field> getNextField = Ship.VerticalOrHorizontalAdvance();

			while (true) {
				yield return field;
				field = getNextField(field);
			}
		}

		public static Field[] Create(in int shipSize, in int worldSitze)
		{
			Field start = new Field {
				x = Ship.rand.Next(0, worldSitze - shipSize + 1),
				y = Ship.rand.Next(0, worldSitze - shipSize + 1),
			};

			return Ship
				.CreateOn(start)
				.Take(shipSize)
				.ToArray();
		}

		public static bool AnyAllive(Field[][] ships)
		{
			foreach (Field[] ship in ships) {
				if (ship.Where(field => !field.hit).Any()) {
					return true;
				}
			}
			return false;
		}
	}
}
