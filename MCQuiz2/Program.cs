using System;
using System.Collections.Generic;

namespace MCQuiz2
{
	class Program
	{
		static void GetQuestions(out string[] questions,
		                         out string[][] answers,
		                         out int[] correctAnswers)
		{
			questions = new string[] {
				"What is C#?",
				"Who is Keanu Reeves?",
				"What is a proton?",
			};
			answers = new string[][] {
				new string[] {
					"Is a joke.",
					"Is a high level programing language",
					"Is a kind of cat"
				},
				new string[] {
					"The best person in the world",
					"The worst person in the world",
					"A girl",
				},
				new string[] {
					"Its a super hero",
					"Its a snack",
					"Its a star system",
					"Its a subatomic particle",
				}
			};
			correctAnswers = new int[] {
				1,
				0,
				3,
			};
		}

		static void PresentQuestion(string question, string[] answers)
		{
			Console.WriteLine(question);
			for (int i = 0; i < answers.Length; ++i) {
				Console.Write(i + 1);
				Console.Write(" - ");
				Console.WriteLine(answers[i]);
			}
		}

		static bool Evaluate(string input, int correctAnswer)
		{
			if (int.TryParse(input, out int parsed) &&
			    parsed - 1 == correctAnswer) {
				Console.WriteLine("That was correct, you are a hero!");
				return true;
			} else {
				Console.WriteLine("That was wrong, u suck!");
				return false;
			}
		}

		static void Main(string[] args)
		{
			Random rand = new Random();
			string[] questions;
			string[][] answers;
			int[] correctAnswers;
			string input;
			int countCorrect = 0, select;
			List<int> alreadyAsked = new List<int>();

			Program.GetQuestions(out questions, out answers, out correctAnswers);

			while (alreadyAsked.Count < questions.Length) {
				select = rand.Next(questions.Length);
				if (alreadyAsked.Contains(select) == false) {
					Program.PresentQuestion(questions[select], answers[select]);
					Console.Write("Choose an anser: ");
					input = Console.ReadLine();
					if (Program.Evaluate(input, correctAnswers[select])) {
						++countCorrect;
					}
					alreadyAsked.Add(select);
				}
			}

			Console.Write("Correct answers: ");
			Console.WriteLine(countCorrect);
		}
	}
}
