using System;

namespace Loop
{
	class Program
	{
		static void Main(string[] args)
		{
			int a = 0;

			while (a != 10) {
				Console.WriteLine(("while", a));
				a = a + 1;
			}

			a = 0;

			do {
				Console.WriteLine(("do", a));
				a = a + 1;
			} while (a != 10);

			for (int i = 0; i < 10; ++i) {
				Console.WriteLine(("for", i));
			}

			foreach (char c in "Hallo") {
				Console.WriteLine(("foreach", c));
			}
		}
	}
}
