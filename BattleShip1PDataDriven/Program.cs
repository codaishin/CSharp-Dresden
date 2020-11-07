using System;
using System.Collections.Generic;

namespace BattleShip1PDataDriven
{
	class Program
	{
		static void TryHit(in bool[,] battleField,
		                   in (int x, int y)[][] ships,
		                   in int[] hits)
		{
			Console.Write("\nAttack field: ");

			string input = Console.ReadLine();
			if (Input.StringToField(input, battleField, out int x, out int y)) {
				battleField[x, y] = true;
				if (Field.HasShip((x, y), ships, out int hit)) {
					++hits[hit];
				}
			} else {
				Console.WriteLine("Input not understood.");
				Console.Write("Press any key to continue ...");
				Console.ReadKey();
			}
		}


		static (int x, int y)[][] NewShips(in int size)
		{
			List<(int x, int y)> usedFields = new List<(int x, int y)>();
			(int x, int y)[][] ships = new (int x, int y)[4][];
			for (int i = 0; i < 4; ++i) {
				ships[i] = Ship.Create(usedFields, i + 1, size);
			}
			return ships;
		}

		static void Main(string[] args)
		{
			int size = 10;
			int attacks = 0;
			bool[,] battleField = new bool[size,size];
			(int x, int y)[][] ships = Program.NewShips(size);
			int[] hits = new int[ships.Length];

			while (Ship.AnyAllive(ships, hits)) {
				Console.Clear();
				Render.BattleField(battleField, ships);
				Console.WriteLine("\nShips hit:");
				Render.Hits(ships, hits);

				Program.TryHit(battleField, ships, hits);
				++attacks;
			}

			Console.Clear();
			Render.BattleField(battleField, ships);
			Console.WriteLine("\nShips hit:");
			Render.Hits(ships, hits);

			Console.WriteLine($"You won with {attacks} attacks");
		}
	}
}
