using System;
using System.Linq;
using System.Collections.Generic;

namespace BattleShip1PDataDriven
{
	static class Ship
	{
		public static Field[] Create(in List<Field> usedFields,
		                             in int shipSize,
		                             in int battleFieldSize)
		{
			Random rand = new Random();
			int startX = rand.Next(0, battleFieldSize - shipSize + 1);
			int startY = rand.Next(0, battleFieldSize - shipSize + 1);
			int dir = rand.Next(0, 2);
			Field[] ship = new Field[shipSize];

			for (int i = 0; i < shipSize; ++i) {
				ship[i] = new Field {
					x = dir == 0 ? startX + i : startX,
					y = dir == 1 ? startY + i : startY,
				};
			}
			foreach (Field field in ship) {
				if (usedFields.Contains(field)) {
					return Ship.Create(usedFields, shipSize, battleFieldSize);
				}
			}
			foreach (Field field in ship) {
				usedFields.Add(field);
			}
			return ship;
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
