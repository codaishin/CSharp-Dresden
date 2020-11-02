using System;

namespace ByRef
{
	class Program
	{
		static bool Is42(in string input, out int value)
		{
			if (input != "42") {
				value = default;
				return false;
			}
			value = 42;
			return true;
		}

		static void MakeArray(int arrayCount, out bool[] array)
		{
			array = new bool[arrayCount];
		}

		static bool AemeliesInput(out string original, out int parsed)
		{
			original = Console.ReadLine();
			return int.TryParse(original, out parsed);
		}

    static void Double(ref float value)
    {
      value *= 2;
    }

		static void Main(string[] args)
		{
			string value = "aisfpiausf";
			int result;
			bool success = Program.Is42(value, out result);
			Console.WriteLine((success, result));

			bool[] array;
			Program.MakeArray(3, out array);
			Console.WriteLine((array[0], array[1], array[2]));

			string originalInput;
			int input;
			success = Program.AemeliesInput(out originalInput, out input);
			Console.WriteLine((success, input, originalInput));

      float number = 21;
      Program.Double(ref number);
      Console.WriteLine(number);
		}
	}
}
