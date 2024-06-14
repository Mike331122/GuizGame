using System;
using System.IO;

namespace QuizGame
{
    class Program
    {
        static string path = Directory.GetCurrentDirectory();
        static string fixedPath = path.Remove(path.IndexOf("bin"), 9);
        static string goodPath = fixedPath + @"Quizquestion\";
        static int filesCount = Directory.GetFiles(goodPath, "*", SearchOption.TopDirectoryOnly).Length;
        static string[] fileNames = Directory.GetFiles(goodPath, "*", SearchOption.TopDirectoryOnly);

        static int mainScore = 0;

        static void Main(string[] args)
        {
            Asking();
            
        }
        /// <summary>
        /// Główna funkcja, która wybiera i odpala quizy
        /// 
        /// Aby dodać qnowy quiz należy dodać plik do folderu Quizquestion w strukturze 
        /// Pytanie ?
        /// 1. Odpowiedż
        /// 2. Odpowiedż
        /// 3. Odpowiedż
        /// >4. Odpowiedż
        /// 
        /// case następny numer:
        ///     Quiz(Nazwa pliku tekstowego)
        ///     break;
        /// 
        /// </summary>
        static void Asking()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();

                Commends.ColorsLine(ConsoleColor.DarkCyan, "Witaj w grze quizowej! Mam przygotowanych parę quizów dla Ciebie.", 'n');
                
                for(int i = 0; i < filesCount; i++)
                {
                    fileNames[i] = fileNames[i].Remove(0, fileNames[i].IndexOf("Quizquestion") + 13);
                    fileNames[i] = fileNames[i].Replace(".txt", "");

                    Commends.ColorsWrite(ConsoleColor.DarkCyan, $"{i + 1}. Quiz o filmie {fileNames[i]}.", 'y');
                }

                Commends.ColorsLine(ConsoleColor.DarkCyan, $"\nTwój główny wynik we wszystkich quizach to {mainScore}\nWpisz '-1' jeśli chcesz zamknąć program");

                int answer = Commends.Checking("Jaką kategorie wybierasz :",1,filesCount,-1);

                switch(answer)
                {
                    case 1:
                        Quiz("Inside out.txt");
                        break;
                    case 2:
                        Quiz("Lord of The Rings.txt");
                        break;
                    case -1:
                        playing = false;
                        break;
                    //Tutaj można dodać komendę case :
                    
                }

            }


        }

        /// <summary>
        /// Metoda odpowiedzialna za odczytanie pliku, wyświetlanie zawartości, sczytywanie odpowiedzi i 
        /// przypisywanie punktów
        /// </summary>
        /// <param name="path">Zawiera nazwe pliku w folderze Quizquestion</param>

        private static void Quiz(string path)
        {
            Console.Clear();

            string[] quiz = File.ReadAllLines(goodPath + path);
            int answear;
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
            mainScore += score;

            Commends.ColorsLine(ConsoleColor.DarkBlue, $"Gratulacje!! Twój wynik to {score}");

            Console.ReadLine();
        }
    }
}
