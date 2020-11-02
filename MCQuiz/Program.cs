using System;

namespace MCQuiz
{
	class Program
	{
		struct Question
		{
			public string question;
			public string[] answers;
			public byte correctAnswer;
		}

		static Program.Question[] GetQuestions()
		{
			return new Program.Question[] {
				new Program.Question {
					question = "What is C#?",
					answers = new string[] {
						"A kind of dog",
						"A musical instrument",
						"A high level programing language",
						"A joke",
						"The best",
					},
					correctAnswer = 2,
				},
				new Program.Question {
					question = "Who is the coolest person in the world?",
					answers = new string[] {
						"Chuck Norris",
						"Captian Kirk",
						"Princess Leia",
						"Keanu Reeves",
					},
					correctAnswer = 3,
				},
			};
		}

		static void PresentQuestion(in Program.Question question)
		{
			Console.WriteLine(question.question);
			for (int i = 0; i < question.answers.Length; ++i) {
				Console.Write((char)(65 + i));
				Console.Write(" - ");
				Console.Write(question.answers[i]);
				Console.WriteLine();
			}
		}

		static void ProcessAnswer(in byte correctAnswer, ref int successes)
		{
			string answer;
			int answerNumber;

			Console.Write("Select an answer: ");
			answer = Console.ReadLine();
			answerNumber = (int)answer[0] - 65;

			if (answerNumber == correctAnswer) {
				Console.WriteLine("Correct!");
				++successes;
			} else {
				Console.WriteLine("Sorry that was incorrect!");
			}
		}

		static void PresentScore(in int successes, in int max)
		{
			Console.Write("Correct ansers: ");
			Console.Write(successes);
			Console.Write(" out of ");
			Console.WriteLine(max);
		}

		static void WaitForContinue()
		{
			Console.Write("Press any key to continue ...");
			Console.ReadKey();
			Console.WriteLine("                             ");
		}

		static void Main(string[] args)
		{
			Program.Question[] questions = Program.GetQuestions();
			int successes = 0;

			foreach (Program.Question question in questions) {
				Program.PresentQuestion(question);
				Program.ProcessAnswer(question.correctAnswer, ref successes);
				Program.WaitForContinue();
			}

			Program.PresentScore(successes, questions.Length);
		}
	}
}
