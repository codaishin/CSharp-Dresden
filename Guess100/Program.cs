using System;
using System.Collections.Generic;

namespace Guess100
{
	class Program
	{
		static void Main(string[] args)
		{
			int goal = new Random().Next(100);
			int input;
			int tries = 0;
			List<int> history = new List<int>();
			string output = string.Empty;

			Console.WriteLine(goal);

			do {
				++tries;
				Console.Write("Guess: ");
				bool wasValidInput = int.TryParse(Console.ReadLine(), out input);
				if(wasValidInput) {
					history.Add(input);
					if (input == goal) {
						output = "You won, congratulations :D";
					} else if (input < goal) {
						output = "Too low";
					} else if (input > goal) {
						output = "Too high";
					}
				} else {
					output = "You need an integer";
				}
				Console.WriteLine(output);
			} while(input != goal);
			Console.WriteLine(("tries", tries));
			Console.WriteLine("valid tries:");
			foreach (int item in history) {
				Console.WriteLine(item);
			}
		}
	}
}
