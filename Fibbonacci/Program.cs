using System;

namespace Fibbonacci
{
	class Program
	{
		static void Main(string[] args)
		{
			if (int.TryParse(args[0], out int from) &&
			    int.TryParse(args[1], out int until)) {
				int a = 0;
				int b = 1;
				int tmp;
				--from;
				for (int i = 0; i < until; ++i) {
					if (i >= from) {
						Console.WriteLine(a);
					}
					tmp = a + b;
					a = b;
					b = tmp;
				}
			} else {
				Console.WriteLine("usage: dotnet run from until");
			}
		}
	}
}
