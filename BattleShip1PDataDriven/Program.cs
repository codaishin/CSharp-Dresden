using System;
using System.Collections.Generic;

namespace BattleShip1PDataDriven
{
	class Program
	{
		static void TryHit(in bool[,] battleField,
		                   in Field[][] ships)
		{
			Console.Write("\nAttack field: ");

			string input = Console.ReadLine();
			if (Input.StringToField(input, battleField, out Field field)) {
				battleField[field.x, field.y] = true;
				if (Field.HasShip(field, ships, out Field[] ship, out int fieldIndex)) {
					ship[fieldIndex].hit = true;
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

			while (Ship.AnyAllive(ships)) {
				Console.Clear();
				Render.BattleField(battleField, ships);
				Render.DebugRenderShips(ships);
				Console.WriteLine("\nShips hit:");
				Render.Hits(ships);

				Program.TryHit(battleField, ships);
				++attacks;
			}

			Console.Clear();
			Render.BattleField(battleField, ships);
			Render.DebugRenderShips(ships);
			Console.WriteLine("\nShips hit:");
			Render.Hits(ships);

			Console.WriteLine($"You won with {attacks} attacks");
		}
	}
}
