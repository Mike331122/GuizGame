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
                        InsideOut();
                        break;
                    case 2:
                        break;
                }

            }


        }

        private static void InsideOut()
        {
            Console.Clear();

            string[] quiz = File.ReadAllLines(goodPath + "Inside out.txt");

            for (int i = 0; i < quiz.Length; i++) 
            {
                Console.WriteLine(quiz[i]);
            }

            Console.ReadLine();
        }
    }
}
