using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip1PDataDriven
{
	class Program
	{
		static void TryHitConsole(in bool[,] battleField, in Field[][] ships)
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

		static
		Field[] NewShip(in int shipSize, in List<Field> fields, in int worldSize)
		{
			Field[] ship = Ship.Create(shipSize, worldSize);
			if (fields.Intersect(ship).Any()) {
				return Program.NewShip(shipSize, fields, worldSize);
			}
			return ship;
		}

		static Field[][] NewShips(in int size, in int worldSize)
		{
			List<Field> usedFields = new List<Field>();
			Field[][] ships = new Field[4][];
			for (int i = 0; i < 4; ++i) {
				ships[i] = Program.NewShip(i + 1, usedFields, worldSize);
				usedFields.AddRange(ships[i]);
			}
			return ships;
		}

		static void RenderFrameToConsole(in bool[,] world, in Field[][] ships)
		{
			Console.WriteLine(string.Join("\n", Render.World(world, ships)));
			Console.WriteLine("\nShips:");
			Console.WriteLine(string.Join(" | ", Render.DebugRenderShips(ships)));
			Console.WriteLine("\nShips hit:");
			Console.WriteLine(string.Join("\n", Render.Hits(ships)));
		}

		static void Main(string[] args)
		{
			int worldSize = 10;
			int attacks = 0;
			bool[,] world = new bool[worldSize,worldSize];
			Field[][] ships = Program.NewShips(worldSize, worldSize);

			while (Ship.AnyAllive(ships)) {
				Program.RenderFrameToConsole(world, ships);
				Program.TryHitConsole(world, ships);
				++attacks;
			}
			Program.RenderFrameToConsole(world, ships);
			Console.WriteLine($"You won with {attacks} attacks");
		}
	}
}
