using System;

namespace Methods
{
	class Program
	{
		static void PrintFoo()
		{
			Console.WriteLine("Foo");
		}

		static int Sum(int a, int b)
		{
			return a + b;
		}

		static bool IsDevisable(int number, int devisorIsEven)
		{
			return number % devisorIsEven == 0;
		}

		static void Main(string[] args)
		{
			int sum = Program.Sum(3, 5);
			int devisorMain = 5;
			Console.WriteLine(sum);

			Console.WriteLine(Program.IsDevisable(10, devisorMain));
			Console.WriteLine(Program.IsDevisable(7, devisorMain));
		}
	}
}
