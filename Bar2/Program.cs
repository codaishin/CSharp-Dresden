using System;
using System.Linq;
using System.Collections.Generic;

namespace Bar2
{
	class Program
	{
		struct ParseInt
		{
			public string original;
			public int parsed;
			public bool success;
		}

		static void PrintBar(int length)
		{
			for (int i = 0; i < length; ++i) {
				Console.Write("|");
			}
			Console.WriteLine();
		}

		static IEnumerable<string> GetInputs(string prompt)
		{
			while (true) {
				Console.Write(prompt);
				yield return Console.ReadLine();
			}
		}

		static ParseInt TryParse(string value)
		{
			Program.ParseInt parse = new Program.ParseInt {
				original = value,
			};
			parse.success = int.TryParse(value, out parse.parsed);
			return parse;
		}

		static Func<Program.ParseInt, bool> NotAborted(params string[] aborts)
		{
			return parse => aborts.Contains(parse.original) == false;
		}

		static Func<Program.ParseInt, bool> OkayOrError(string errorMessage)
		{
			return parse => {
				if (parse.success == false) {
					Console.WriteLine(errorMessage);
				}
				return parse.success;
			};
		}

		static void Main(string[] args)
		{
			Program.ParseInt[] inputs = Program.GetInputs("Input (stop with q|Q): ")
				.Select(Program.TryParse)
				.TakeWhile(Program.NotAborted("q", "Q"))
				.Where(Program.OkayOrError("ignoring unrecognised value"))
				.ToArray();

			foreach(Program.ParseInt input in inputs) {
				Program.PrintBar(input.parsed);
			}
		}
	}
}
