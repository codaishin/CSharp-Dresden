using System;
using System.Collections.Generic;

namespace BattleShip1PDataDriven
{
	static class Ship
	{
		public static (int x, int y)[] Create(in List<(int x, int y)> usedFields,
		                                      in int shipSize,
		                                      in int battleFieldSize)
		{
			Random rand = new Random();
			int startX = rand.Next(0, battleFieldSize - shipSize + 1);
			int startY = rand.Next(0, battleFieldSize - shipSize + 1);
			int dir = rand.Next(0, 2);
			(int x, int y)[] ship = new (int x, int y)[shipSize];

			for (int i = 0; i < shipSize; ++i) {
				ship[i] = dir == 0 ? (startX + i, startY) : (startX, startY + i);
			}
			foreach ((int x, int y) field in ship) {
				if (usedFields.Contains(field)) {
					return Ship.Create(usedFields, shipSize, battleFieldSize);
				}
			}
			foreach ((int x, int y) field in ship) {
				usedFields.Add(field);
			}
			return ship;
		}

		public static bool AnyAllive((int x, int y)[][] ships, int[] hits)
		{
			for (int i = 0; i < hits.Length; ++i) {
				if (hits[i] < ships[i].Length) {
					return true;
				}
			}
			return false;
		}
	}
}
