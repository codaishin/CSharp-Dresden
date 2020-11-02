using System;
using System.Threading;

namespace CustomProject
{
	class Program
	{
		static void GameLoop(ref GameObject player, ref GameObject monster)
		{
			bool playerTurn = true;
			while (monster.hp > 0 && player.hp > 0) {
				GameObject.Render(player, monster);
				if (playerTurn) {
					Program.PlayerAction(ref player, ref monster);
				} else {
					Program.MonsterAction(ref monster, ref player);
				}
				playerTurn = !playerTurn;
				Thread.Sleep(1000);
			}
		}

		static void PlayerAction(ref GameObject player, ref GameObject monster)
		{
			switch (Action.SelectAction()) {
				case ConcreteAction.Attack:
					GameObject.Attack(ref player, ref monster);
					break;
				case ConcreteAction.Dodge:
					GameObject.Dodge(ref player);
					break;
				default:
					GameObject.Idle(ref player);
					break;
			}
		}

		static void MonsterAction(ref GameObject monster, ref GameObject player)
		{
			GameObject.Attack(ref monster, ref player);
		}

		static void GameOver(in GameObject player, in GameObject monster)
		{
			if (monster.hp <= 0) {
				Console.WriteLine("You won");
			} else {
				Console.WriteLine("You lost");
			}
		}

		static void Main(string[] _)
		{
			Info.Intro();
			GameObject.Init(out GameObject player, out GameObject monster);
			Info.Stats(player);
			Info.Stats(monster);
			Program.GameLoop(ref player, ref monster);
			Program.GameOver(player, monster);
		}
  }
}
