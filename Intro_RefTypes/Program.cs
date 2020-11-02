using System;
using System.Collections.Generic;

namespace RefTypes
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] numbersA = new int[10];
			int[] numbersB = numbersA;
			List<int> listA = new List<int>() { 10, 2, 3 };
			listA.Add(42);

			for (int i = 0; i < numbersA.Length; i++) {
				numbersA[i] = i;
			}

			numbersB = new int[10];

			foreach (int number in numbersA) {
				Console.WriteLine(("A", number));
			}
			foreach (int number in numbersB) {
				Console.WriteLine(("B", number));
			}
			foreach (int number in listA) {
				Console.WriteLine(("LA", number));
			}
		}
	}
}
