using System;

namespace Classes
{
	class Person
	{
		// Fields
		public string name;
		public int age;

		// Methods
		public override string ToString()
		{
			return this.name;
		}

		public void Birthday()
		{
			++this.age;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Person person = new Person { name = "Harry", age = 38 };
			Console.WriteLine(person.age);
			person.Birthday();
			Console.WriteLine(person.age);
		}
	}
}
