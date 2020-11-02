using System;

namespace Foo
{
	class Program
	{
		static int GetInput(string promt)
		{
			Console.Write(promt);
			int inputValue;
			string inputStr = Console.ReadLine();
			if(int.TryParse(inputStr, out inputValue) == false) {
				Console.WriteLine("U suck");
				return Program.GetInput(promt);
			}
			return inputValue;
		}

		static float Power(int value, int power)
		{
			int tmp = value;
			if(power > 0) {
				for(int i = 1; i < power; ++i) {
					value = value * tmp;
				}
				return value;
			}
			if(power < 0) {
				return 1f / Program.Power(value, -power);
			}
			return 1;
		}

		static void Main(string[] args)
		{
			int powerBase = Program.GetInput("Base: ");
			int powerFactor = Program.GetInput("Power: ");
			float powerResult = Program.Power(powerBase, powerFactor);
			Console.WriteLine(("base", powerBase));
			Console.WriteLine(("power", powerResult));
		}
	}
}
