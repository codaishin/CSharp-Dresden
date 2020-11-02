using System;

namespace Primes
{
	class Program
	{
		static bool IsPrime(int number)
		{
			bool isPrime = true;
			for (int i = 2; i < number && isPrime; ++i) {
				if (number % i == 0) {
					isPrime = false;
				}
			}
			return isPrime;
		}

		static void Main(string[] args)
		{
			int primeCount = 0;
			int targetCount;
			if (int.TryParse(args[0], out targetCount)) {
				for (int n = 2; primeCount < targetCount; ++n) {
					if (Program.IsPrime(n)) {
						Console.WriteLine(n);
						++primeCount;
					}
				}
			} else {
				Console.WriteLine("usage: dotnet run <count>");
			}
		}
	}
}
