using System;

namespace Cars
{
	class Car
	{
		// Fields
		private int speed;

		// Properties
		public int Speed {
			get {
				return this.speed;
			}
			set {
				if (value > 100) {
					this.speed = 100;
				} else if (value < 0) {
					this.speed = 0;
				} else {
					this.speed = value;
				}
			}
		}

		public int BetterSpeed {
			get => this.speed;
			set => this.speed = Math.Clamp(value, 0, 100);
		}

		// Constructors
		public Car() {}

		public Car(int initialSpeed)
		{
			this.Speed = initialSpeed;
		}

		// Methods
		public void SlowDown()
		{
			this.Speed -= 5;
		}

		public void SpeedUp()
		{
			this.Speed += 5;
		}
	}
}
