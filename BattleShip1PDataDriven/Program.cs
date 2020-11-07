using System;
using System.Collections.Generic;

namespace BattleShip1PDataDriven
{
	class Program
	{
		static void TryHit(in bool[,] battleField,
		                   in Field[][] ships,
		                   in int[] hits)
		{
			Console.Write("\nAttack field: ");

			string input = Console.ReadLine();
			if (Input.StringToField(input, battleField, out Field field)) {
				battleField[field.x, field.y] = true;
				if (Field.HasShip(field, ships, out int hit)) {
					++hits[hit];
				}
			} else {
				Console.WriteLine("Input not understood.");
				Console.Write("Press any key to continue ...");
				Console.ReadKey();
			}
		}


		static Field[][] NewShips(in int size)
		{
			List<Field> usedFields = new List<Field>();
			Field[][] ships = new Field[4][];
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
			Field[][] ships = Program.NewShips(size);
			int[] hits = new int[ships.Length];

			while (Ship.AnyAllive(ships, hits)) {
				Console.Clear();
				Render.BattleField(battleField, ships);
				Render.DebugRenderShips(ships);
				Console.WriteLine("\nShips hit:");
				Render.Hits(ships, hits);

				Program.TryHit(battleField, ships, hits);
				++attacks;
			}

			Console.Clear();
			Render.BattleField(battleField, ships);
			Render.DebugRenderShips(ships);
			Console.WriteLine("\nShips hit:");
			Render.Hits(ships, hits);

			Console.WriteLine($"You won with {attacks} attacks");
		}
	}
}
