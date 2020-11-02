using System;
using System.Collections.Generic;

namespace Bars
{
	class Program
	{
		struct ParseInt
		{
			public string original;
			public int parsed;
			public bool success;
		}

		static void PrintBars(int count)
		{
			for (int i = 0; i < count; ++i) {
				Console.Write("|");
			}
			Console.WriteLine();
		}

		static Program.ParseInt GetInput(string prompt)
		{
			Program.ParseInt parse = new Program.ParseInt();

			Console.Write(prompt);

			parse.original = Console.ReadLine();
			if (int.TryParse(parse.original, out parse.parsed)) {
				parse.success = true;
			}
			return parse;
		}

		static void Main(string[] args)
		{
			bool running = true;
			Program.ParseInt parse;
			List<int> barSizes = new List<int>();

			while (running) {
				parse = Program.GetInput("Input (q to stop): ");
				if (parse.original == "q") {
					running = false;
				} else if (parse.success) {
					barSizes.Add(parse.parsed);
				} else {
					Console.WriteLine("Ignoring unrecognised value!");
				}
			}

			foreach(int size in barSizes) {
				Program.PrintBars(size);
			}
		}
	}
}
