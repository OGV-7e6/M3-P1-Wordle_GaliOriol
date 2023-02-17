using System;
using System.IO;


namespace M3P1WordleGaliOriol
{
    class Wordle
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Wordle index = new Wordle();
            index.Menu();
        }

        public void Menu()
        {
            string option;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\t\t\t    _     _  _______  ______    ______   ___      _______    \n" +
                                  "\t\t\t   | | _ | ||       ||    _ |  |      | |   |    |       |   \n" +
                                  "\t\t\t   | || || ||   _   ||   | ||  |  _    ||   |    |    ___|   \n" +
                                  "\t\t\t   |       ||  | |  ||   |_||_ | | |   ||   |    |   |___    \n" +
                                  "\t\t\t   |       ||  |_|  ||    __  || |_|   ||   |___ |    ___|   \n" +
                                  "\t\t\t   |   _   ||       ||   |  | ||       ||       ||   |___    \n" +
                                  "\t\t\t   |__| |__||_______||___|  |_||______| |_______||_______|   \n" +
                                  "\t\t\t                                                             ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\t\t\t1.- Jugar.");
                Console.WriteLine("\t\t\t2.- Reglas.");
                Console.WriteLine("\t\t\t2.- Idioma.");
                Console.WriteLine("\t\t\t3.- Tabla de puntuaciones.");
                Console.WriteLine("\t\t\t0.- Salir.");
                Console.ResetColor();

                Console.Write("\n\t\t\tOpcion>>>>> ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        GameLoop();
                        Console.ReadLine();
                        break;

                    case "2":
                        Rules();
                        Console.ReadLine();
                        break;

                    default:
                        break;
                }
            } while (option != "0");
            
        }


        public void Rules()
        {
            
            Console.WriteLine("\t\t\t-RULES-\n");
            Console.WriteLine("\t\t\t - Green = The word has the letter in this position");
            Console.WriteLine("\t\t\t - Yellow = The word has the letter but in other position");
            Console.WriteLine("\t\t\t - Gray = The word dont has the letter in any position");
            Console.WriteLine("\t\t\t - You only have 6 atempts to guess.");
            Console.WriteLine("\t\t\t - The words must be 5 letters.");
            Console.WriteLine("\t\t\t - Looking at the code is cheat. ;)");
            Console.WriteLine("\t\t\t - And finaly, you MUST enjoy. >:D");
        }

        public void GameLoop()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nLETS PLAY WORDLE!\n");
            Console.ResetColor();

            const int maxAttempts = 6;
            Random randomNum = new Random();
            string[] posibleWords = {"VEJEZ", "ZARZA", "JUZGO", "CAZAR", "CALIZ", "JAULA", "ZAMPA", "VELOZ", "JEQUE", "MATIZ", "MAZOS", "PUZLE", "PATAS", "ROJEZ", "JUEGO", "CHUSO", "XOKAS", "PIZCA", "FEROZ", "JAMAL"};
            string word2Guess = posibleWords[randomNum.Next(0, 20)];
            string userWord;
            bool win = false;
            Console.WriteLine(word2Guess);


            for (int attempts = 0; attempts < maxAttempts || win == false; attempts++)//Atempt counter 
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
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congrats, you won!! :D");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
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
                    Console.ResetColor();
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
