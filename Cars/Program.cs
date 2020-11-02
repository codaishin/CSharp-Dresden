using System;

namespace Cars
{
	class Program
	{
		static void Main(string[] args)
		{
			Car car = new Car() { Speed = 100 };
			Console.WriteLine(car.Speed);

			car.SlowDown();
			Console.WriteLine(car.Speed);

			car.SlowDown();
			Console.WriteLine(car.Speed);

			car.SpeedUp();
			Console.WriteLine(car.Speed);
		}
	}
}
