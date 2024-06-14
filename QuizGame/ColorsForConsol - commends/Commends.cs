using System;

namespace QuizGame
{
     static class Commends
    {

        public static void ColorsWrite(ConsoleColor color, string write, char line = 'y')
        {
            Console.ForegroundColor = color;

            switch (line)
            {
                case 'y':
                    Console.Write($"\n{ write}");
                    break;
                case 'n':
                    Console.Write($"{write}");
                    break;
            }

            Console.ResetColor();
        }

        public static void ColorsLine(ConsoleColor color, string write, char line = 'y')
        {
            Console.ForegroundColor = color;

            switch (line)
            {
                case 'y':
                    Console.WriteLine($"\n{ write}");
                    break;
                case 'n':
                    Console.WriteLine($"{write}");
                    break;
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Sprawdza czy ciąg znaków jest liczbą
        /// </summary>
        /// <param name="write">Napis który komenda ma wyświetlić żeby zapytać użytkownika co ma robić</param>
        /// <returns></returns>
        public static int Checking(string write)
        {
            int number = 0;
            bool var_Correct = true;
            string check;

            while (var_Correct)
            {
                ColorsWrite(ConsoleColor.Green, write);

                check = Console.ReadLine();

                if (Int32.TryParse(check, out number))
                {
                    var_Correct = false;
                }
                else
                {
                    ColorsLine(ConsoleColor.Red, "Nie rozpoznano znaku.");

                }
            }

            return number;
        }

        /// <summary>
        /// Sprawdza czy ciąg znaków jest liczbą oraz czy podana cyfra znajduje się w przedziale
        /// </summary>
        /// <param name="write">Jakie pytanie ma program zadać</param>
        /// <param name="minValue">Najmniejsza wartość jaką można podać</param>
        /// <param name="maxValue">Największa wartość jaką można podać</param>
        /// <returns></returns>
        public static int Checking(string write, int minValue, int maxValue)
        {
            int number = 0;
            bool var_Correct = true;
            string check;

            while (var_Correct)
            {
                ColorsWrite(ConsoleColor.Green, write);

                check = Console.ReadLine();

                if (Int32.TryParse(check, out number))
                {
                    if(number >= minValue && number <= maxValue)
                    {
                        var_Correct = false;
                    }
                    else
                    {
                        ColorsLine(ConsoleColor.Red, "Cyfra nie znajduje się w przedziale.");
                    }
                    
                }
                else
                {
                    ColorsLine(ConsoleColor.Red, "Nie rozpoznano znaku.");

                }
            }

            return number;
        }

        /// <summary>
        /// Sprawdza czy cyfra nie jest zerem
        /// </summary>
        /// <param name="notZero">Sprawdzana cyfra</param>
        /// <returns></returns>
        public static int Checking(int notZero)
        {
            bool var_Correct = true;


            while (var_Correct)
            {
                if (notZero == 0)
                {
                    ColorsLine(ConsoleColor.Red, "Nie można dzielić przez zero.  ");
                    notZero = Checking("Podaj poprawną liczbę: ");
                }
                else
                {
                    var_Correct = false;
                }
            }
            return notZero;
        }
    }

}

