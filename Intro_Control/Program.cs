using System;

namespace Control
{
	class Program
	{
		static void Main(string[] args)
		{
			int a = 41;

			/* If-Else assignment */
			// string output = a == 42 ? "Winner" : "Loser";
			string output;
			if (a == 42) {
				output = "Winner";
			} else {
				output = "Loser";
			}

			Console.WriteLine(output);

			/* If-Else */
			if (a == 42) {
				Console.WriteLine("You won");
			} else if (a == 43 || a == 41) {
				Console.WriteLine("Almost there");
			} else {
				Console.WriteLine("You lost");
			}
			if (a == 42) {
				Console.WriteLine("You won");
			} else if (a < 42) {
				Console.WriteLine("Too small");
			} else if (a > 42) {
				Console.WriteLine("Too big");
			}
			// }	else {
			// 	Console.WriteLine("You lost");
			// }

			/* Switch Case */
			switch (a) {
				case 42:
					Console.WriteLine("You won");
					break;
				case 41:
				case 43:
					Console.WriteLine("Almost there");
					break;
				default:
					Console.WriteLine("You lost");
					break;
			}
		}
	}
}
