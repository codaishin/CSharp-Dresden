using System;

namespace Structs
{
	class Program
	{
		struct Person
		{
			public string name;
			public int age;
		}

		static void Main(string[] args)
		{
			Person person = new Person {
				name = "Harry Haller",
				age = 42
			};
			Console.WriteLine(person.name);
			Console.WriteLine(person.age);
		}
	}
}
