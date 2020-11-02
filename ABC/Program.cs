using System;

namespace ABC
{
	class Program
	{
		struct Book
		{
			public string autor;
			public string title;
			public uint pages;
		}

		static float Sum(float a, float b)
		{
			if (a > 0 && b > 0) {
				return a + b;
			}
			return -1;
		}

		static void Main(string[] args)
		{
			float result = Program.Sum(3, 4);
			Book theBook = new Book();
			theBook.autor = "Jesus";
			theBook.title = "Bible";
			theBook.pages = 10;
			Book theOtherBook = new Book() {
				autor = "Max",
				title = "Das Buch",
				pages = 1
			};
			Console.WriteLine(result);
		}
	}
}
