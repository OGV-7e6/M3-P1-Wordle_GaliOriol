using System;
using System.IO;


namespace M3P1WordleGaliOriol
{
    class Wordle
    {
        static void Main(string[] args)
        {
            Wordle menu = new Wordle();
            menu.Menu();
        }

        public void Menu()
        {
            const int maxAttempts = 6;
            string option;
            string path = @"C:\Users\Uri\OneDrive\Escriptori\wordle";
            string langPath = @"\lang\en.txt";
            string[] textLines;

            textLines = SetLanguage(langPath, path);

            langPath = ChangeLanguage(textLines);
            textLines = SetLanguage(langPath, path);


            do
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                StreamReader sr = File.OpenText(path + @"\title.txt");
                Console.WriteLine(sr.ReadToEnd());


                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = ConsoleColor.Black;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(textLines[i]);
                }
                Console.Write(textLines[5] + "\t");
                
                Console.ResetColor();
                option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        break;

                    case "1":
                        GameLoop(maxAttempts, path, textLines);
                        break;

                    case "2":
                        Rules(maxAttempts, textLines);
                        Console.ReadLine();
                        break;

                    case "3":
                        langPath = ChangeLanguage(textLines);
                        textLines = SetLanguage(langPath, path);
                        break;

                    case "4":
                        ScoreBoard(path);
                        break;

                    default:
                        break;
                }
            } while (option != "0");
            
        }
        
        public void GameLoop(int maxAttempts, string path, string[] textLines)
        {
            string[] posibleWords = { "JAMAL", "PIEZA" };//insertar las palabras desde el fichero.

            
            Random randomNum = new Random();
            string word2Guess = posibleWords[randomNum.Next(0, posibleWords.Length)];
            string userWord;
            bool win = false;
            int points;


            Console.WriteLine(word2Guess);


            for (int attempts = maxAttempts; 0 < attempts ; attempts--)//Atempt counter 
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n" + attempts + textLines[13]);
                Console.ResetColor();

                //User imput

                do
                {
                    userWord = Console.ReadLine().ToUpper();

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (userWord.Length < word2Guess.Length) Console.WriteLine(textLines[14] + "\n");
                    if (userWord.Length > word2Guess.Length) Console.WriteLine(textLines[15] + "\n");
                    Console.ResetColor();

                } while (userWord.Length != word2Guess.Length);


                //User imput analysis and treatment

                if (userWord == word2Guess)
                {
                    //Guessed word all in green
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(userWord);
                    Console.ResetColor();

                    //Victory message
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(textLines[16]);
                    Console.ResetColor();

                    points = attempts * 120;
                    attempts = 0;
                    win = true;

                    savePoints(points, path, textLines);
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
                    Console.WriteLine("");
                }
                Console.ResetColor();

                
            }
            if (win == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(word2Guess);
                Console.ResetColor();
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(textLines[17]);
                Console.ResetColor();
            }
        }

        public string[] SetLanguage(string langPath, string path)
        {
            return File.ReadAllText(path + langPath).Split("\n");
        }

        public string ChangeLanguage(string[] textLines)
        {
            Console.Clear();
            string option;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{textLines[2].Replace("3.- ", "").Replace(".", "-------------")}\n");
            Console.WriteLine("1. English");
            Console.WriteLine("2. Español");



            while (true)
            {
                Console.Write(">> ");
                option = Console.ReadLine();

                switch (option)
                {
                        
                    case "1":
                        return @"\lang\en.txt";

                    case "2":
                        return @"\lang\es.txt";

                    default:
                        break;
                }
            }
        }

        public void Rules(int maxAttempts, string[] textLines)
        {
            Console.WriteLine(textLines[6]);
            Console.WriteLine(textLines[7]);
            Console.WriteLine(textLines[8]);
            Console.WriteLine($"{textLines[9]}\t\t\t\t{maxAttempts}");
            Console.WriteLine(textLines[10]);
            Console.WriteLine(textLines[11]);
            Console.WriteLine(textLines[12]);
        }

        public bool savePoints(int points, string path, string[] textLines)
        {
            string content = $"{points}\n";

            if (File.Exists(path + @"\score.txt"))
            {
                StreamWriter sw = File.AppendText(path + @"\score.txt");

                Console.WriteLine($"\n{textLines[18]}");
                content += ($"{Console.ReadLine()}");

                sw.WriteLine(content);

                sw.Close();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void ScoreBoard(string path)
        {   
            //even positions are points and the odd ones are names.
            string[] scoresAndNames = File.ReadAllText(path + @"\score.txt").Split("\n");

            for (int i = 0; i < scoresAndNames.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"{scoresAndNames[i]} {scoresAndNames[i + 1]}");
                }
            }

            
        }
    }
}
