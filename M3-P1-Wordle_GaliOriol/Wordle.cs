using System;
using System.IO;


namespace M3P1WordleGaliOriol
{
    public class Wordle
    {
        static void Main(string[] args)
        {
            Wordle menu = new Wordle();
            menu.Menu();
        }

        /// <summary>
        /// A Menu That conects all the functions of the game.
        /// </summary>
        public void Menu()
        {
            const int maxAttempts = 6;
            string option;
            string path = @"..\..\..\files";
            string langPath = @"\lang\en\lang.txt";
            string[] textLines;

            textLines = File2Array(langPath, path);

            langPath = ChangeLanguage(textLines);
            textLines = File2Array(langPath, path);


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
                Console.Write(textLines[5]);
                
                Console.ResetColor();
                option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        break;

                    case "1":
                        GameLoop(maxAttempts, path, langPath, textLines);
                        break;

                    case "2":
                        Rules(maxAttempts, textLines);
                        Console.ReadLine();
                        break;

                    case "3":
                        langPath = ChangeLanguage(textLines);
                        textLines = File2Array(langPath, path);
                        break;

                    case "4":
                        ScoreBoard(path);
                        Console.ReadLine();
                        break;

                    default:
                        break;
                }
            } while (option != "0");
            
        }
        
        /// <summary>
        /// This function executes the game.
        /// </summary>
        /// <param name="maxAttempts"></param>
        /// <param name="path"></param>
        /// <param name="langPath"></param>
        /// <param name="textLines"></param>
        public void GameLoop(int maxAttempts, string path, string langPath, string[] textLines)
        {
            string[] posibleWords = File2Array(langPath.Replace("lang.txt","words.txt"), path);


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
                    userWord = Console.ReadLine().ToLower();

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

                    points = attempts;
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

        /// <summary>
        /// It reads all the file, and then splits it on the line breaks.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <returns>An array with each line on a position</returns>
        public string[] File2Array(string file, string path)
        {
            return File.ReadAllText(path + file).Replace("\r","").Split("\n");
        }
        
        /// <summary>
        /// Requests the user wich language wants.
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns>A string with the path to the language file requested.</returns>
        public string ChangeLanguage(string[] textLines)
        {
            string option;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{textLines[2].Replace("3.- ", "").Replace(".", "-------------")}\n");
            Console.WriteLine("en -> English");
            Console.WriteLine("es -> Español");



            while (true)
            {
                Console.Write(">> ");
                option = Console.ReadLine();
                if ( option == "en" || option == "es" )
                {
                    return $@"\lang\{option}\lang.txt";
                }

            }
        }

        /// <summary>
        /// It prints the rules on console.
        /// </summary>
        /// <param name="maxAttempts"></param>
        /// <param name="textLines"></param>
        public void Rules(int maxAttempts, string[] textLines)
        {
            Console.WriteLine("");
            Console.WriteLine(textLines[6]);
            Console.WriteLine(textLines[7]);
            Console.WriteLine(textLines[8]);
            Console.WriteLine($"{textLines[9]} {maxAttempts}");
            Console.WriteLine(textLines[10]);
            Console.WriteLine(textLines[11]);
            Console.WriteLine(textLines[12]);
        }


        /// <summary>
        /// Asks the palyer's name and writes that name and the points on two lines of a file.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="path"></param>
        /// <param name="textLines"></param>
        /// <returns>True if the points are saved or False if the Score.txt is missing.</returns>
        public bool savePoints(int points, string path, string[] textLines)
        {
            if (File.Exists(path + @"\score.txt"))
            {
                StreamWriter sw = File.AppendText(path + @"\score.txt");

                Console.Write($"\n{textLines[18]}");
                string name = Console.ReadLine();
                sw.WriteLine(name) ;
                sw.WriteLine(points);

                sw.Close();

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Prints on console the name of the player and the score on that attempt.
        /// </summary>
        /// <param name="path"></param>
        public void ScoreBoard(string path)
        {   
            //even positions are points and the odd ones are names.
            string[] scoresAndNames = File.ReadAllText(path + @"\score.txt").Replace("\r","").Split("\n");

            Console.WriteLine("");
            for (int i = 0; i < scoresAndNames.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($" -{scoresAndNames[i]} ----- {scoresAndNames[i + 1]}");
                }
            }

            
        }
    }
}
