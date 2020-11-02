using System;

namespace Strings
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = @"C:\Documents";
			Console.WriteLine(path);

			string a = $"the answer is {4}";
			Console.WriteLine("{1}: the answer is {0}", 4, "Smurf");

			Console.WriteLine($"{"Smurf"}: the answer is {4}");

			string b = string.Format("{0}: {1}", "ZZZ", 5);
			Console.WriteLine(b);

			Console.WriteLine(("Foo", 4));
			Console.WriteLine($"Foo is {4:F2}");

			Console.WriteLine("\thello\nu\thow are u");

			int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
			Console.WriteLine(string.Join(", ", numbers));

			string concat = "Hello";
			concat += ", World!";
			Console.WriteLine(concat);

			string longString = "aaaaaaaaaajjjjjjjjjjjjjjjddddddddddd";
			string substring = longString.Substring(5, longString.IndexOf('j') - 5);

			Console.WriteLine(substring.PadLeft(40));
		}
	}
}
