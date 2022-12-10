using System;

namespace M3_P1_Wordle_GaliOriol
{
    class Wordle
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  _     _  _______  ______    ______   ___      _______  \n" + 
                              " | | _ | ||       ||    _ |  |      | |   |    |       | \n" + 
                              " | || || ||   _   ||   | ||  |  _    ||   |    |    ___| \n" + 
                              " |       ||  | |  ||   |_||_ | | |   ||   |    |   |___  \n" + 
                              " |       ||  |_|  ||    __  || |_|   ||   |___ |    ___| \n" + 
                              " |   _   ||       ||   |  | ||       ||       ||   |___  \n" + 
                              " |__| |__||_______||___|  |_||______| |_______||_______| \n" +
                              "                                                         ");
            Console.ResetColor();
            GameLoop();
        }
        public static void GameLoop()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nLETS PLAY WORDLE!\n");
            Console.ResetColor();

            Random randomNum = new Random();
            const int maxAttempts = 6;
            string[] posibleWords = {"VEJEZ", "ZARZA", "JUZGO", "CAZAR", "CALIZ", "JAULA", "ZAMPA", "VELOZ", "JEQUE", "MATIZ", "MAZOS", "PUZLE", "PATAS", "ROJEZ", "JUEGO", "CHUSO", "XOKAS", "PIZCA", "FEROZ", "JAMAL"};
            string word2Guess = posibleWords[randomNum.Next(0, 20)];
            string userWord;

            for (int attempts = 0; attempts < maxAttempts; attempts++)//Atempt counter 
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Atempt " + (attempts + 1));
                Console.ResetColor();

                //User imput
                do
                {
                userWord = Console.ReadLine().ToUpper();
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (userWord.Length < word2Guess.Length)
                    {
                        Console.WriteLine("The word is too short\n");
                    }
                    if (userWord.Length > word2Guess.Length)
                    {
                        Console.WriteLine("The word is too long\n");
                    }
                    Console.ResetColor();
                } while (userWord.Length != word2Guess.Length);

                //User imput analysis and treatment
                if (userWord == word2Guess)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(userWord);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congrats, you won!! :D");
                    Console.ResetColor();
                    GameLoop();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < word2Guess.Length; i++)
                    {
                        if (word2Guess[i] == userWord[i])
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(userWord[i]);
                        }
                        else if (word2Guess.Contains(userWord[i]))
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write(userWord[i]);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(userWord[i]);
                        }
                    }
                }
                Console.ResetColor();
                Console.WriteLine("\n");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You ran out of attempts :(");
            Console.ResetColor();
            GameLoop();
        }
    }
}
