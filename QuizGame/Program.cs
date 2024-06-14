using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    class Program
    {
        static string path = Directory.GetCurrentDirectory();
        static string fixedPath = path.Remove(path.IndexOf("bin"), 9);
        static string goodPath = fixedPath + @"Quizquestion\";

        static int mainScore = 0;

        static void Main(string[] args)
        {
            Asking();
            
        }

        static void Asking()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();

                Commends.ColorsLine(ConsoleColor.DarkCyan, "Witaj w grze quizowej! Mam przygotowanych parę quizów dla Ciebie.", 'n');
                Commends.ColorsLine(ConsoleColor.DarkCyan, "1. Quiz o filmie Inside Out.");
                //Commends.ColorsLine(ConsoleColor.DarkCyan, "2. Quiz.");

                int answer = Commends.Checking("Jaką kategorie wybierasz :", 1, 2);

                switch(answer)
                {
                    case 1:
                        Quiz("Inside out.txt");
                        break;
                    case 2:
                        break;
                }

            }


        }

        private static void Quiz(string path)
        {
            Console.Clear();

            string[] quiz = File.ReadAllLines(goodPath + path);
            int answear = 0;
            int goodAnswear = 1;
            int score = 0;

            for (int i = 0; i < quiz.Length; i++) 
            {

                if(quiz[i].Contains("?"))
                {
                    Commends.ColorsWrite(ConsoleColor.Cyan, quiz[i], 'n');
                }
                else if(quiz[i].StartsWith("1")|| quiz[i].StartsWith("2") || quiz[i].StartsWith("3") || quiz[i].StartsWith("4"))
                {
                    Commends.ColorsWrite(ConsoleColor.Green, quiz[i]);
                }
                else if (quiz[i].StartsWith(">"))
                {
                    quiz[i] = quiz[i].Replace(">", "");
                    goodAnswear = Int32.Parse(quiz[i].Substring(0, 1));
                    Commends.ColorsWrite(ConsoleColor.Green, quiz[i]);
                }

                if(quiz[i].StartsWith("4"))
                {
                    answear = Commends.Checking("Podaj odpowiedź :", 1, 4);

                    if(answear == goodAnswear)
                    {
                        Commends.ColorsLine(ConsoleColor.Blue, "Poprawnie!! \n", 'n');
                        score++;
                    }
                    else
                        Commends.ColorsLine(ConsoleColor.Red, "Zła odpowiedź \n", 'n');
                }

            }

            Commends.ColorsLine(ConsoleColor.DarkBlue, $"Gratulacje!! Twój wynik to {score}");

            Console.ReadLine();
        }
    }
}
