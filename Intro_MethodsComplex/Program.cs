using System;

namespace MethodsComplex
{
	class Program
	{
		static void Foo(int value)
		{
			value = 8;  // just a copy
		}

		static void Foo(ref int value)
		{
			value = 8;
		}

		static void Bar(in int value)
		{
			// value = 9; Doesn't work, "in" makes it read-only
			Console.WriteLine(value);
		}

		static void Bar(in int[] value)
		{
			value[0] = -1;
			// value = new int[] { -1, -2 }; Doesn't work, "in" makes it read-only
		}

		static void FooOut(out int value)
		{
			value = 33;  // This must be done!
		}

		static void FooOut(out int[] value)
		{
			value = new int[] { -1, -5 };  // This must be done!
		}

		static void Foo(int[] values)
		{
			values[0] = -5;  // edit "original array"
			values = new int[] { 42, 0 };  // values forgets "original array"
		}

		static void Foo(ref int[] values)
		{
			values = new int[] { -1, -2 };
		}

		static void Main(string[] args)
		{
			int a = 4;
			int[] b = new int[] { 1, 2 };  // "original array"
			Program.Foo(a); // int value = a;
			Program.Foo(b); // int[] value = b;
			Console.WriteLine(a);
			Console.WriteLine((b[0], b[1]));

			int aRef = 4;
			int[] bRef = new int[] { 1, 2 }; // "orignal array 2"
			Program.Foo(ref aRef); // ref int value = aRef; alias, NO COPY!!!!!!!!!!!
			Program.Foo(ref bRef); // ref int[] value = bRef; alisa, NOT ONLY POINTING TO SAME!!!!!!!
			Console.WriteLine(aRef);
			Console.WriteLine((bRef[0], bRef[1]));

			int aOut;
			Program.FooOut(out aOut);
			Console.WriteLine(aOut);
		}
	}
}
