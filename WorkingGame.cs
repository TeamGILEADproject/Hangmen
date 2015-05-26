using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WorkingGame
{
    public class WorkingGame
    {
        public static int StartMenu()
        {
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "БЕСЕНИЦА"));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "created by Team GILEAD"));
            Console.WriteLine("За игра въведете 1");
            Console.WriteLine("За да въведете нова дума въведете 0");
            int startInput;
            string strLetter;

            string[] container = { "a", "b", "c", "d", "e", "f", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            strLetter = Console.ReadLine().ToLower();

            if (strLetter == "0" || strLetter == "1" || strLetter == "2" || strLetter == "3" || strLetter == "4" || strLetter == "5" || strLetter == "6" || strLetter == "7"
                || strLetter == "8" || strLetter == "9" || strLetter == "10")
            {
                do
                {
                    Console.WriteLine("Моля  изберете  опция от главното меню: 0 или 1 ако сте го направили потвърдете като повторите избора си");
                    startInput = Int32.Parse(Console.ReadLine());




                } while (startInput != 0 && startInput != 1);


                return startInput;
            }
            else
            {


                for (int i = 0; i < container.Length; i++)
                {
                    if (strLetter == container[i] || strLetter == container[i + 1] || strLetter == container[i + 2] || strLetter == container[i + 3] || strLetter == container[i + 4]
                        || strLetter == container[i + 5] || strLetter == container[i + 6] || strLetter == container[i + 7] || strLetter == container[i + 8]
                        || strLetter == container[i + 9] || strLetter == container[i + 10] || strLetter == container[i + 11] || strLetter == container[i + 12]
                        || strLetter == container[i + 13] || strLetter == container[i + 14] || strLetter == container[i + 15] || strLetter == container[i + 16]
                        || strLetter == container[i + 17] || strLetter == container[i + 18] || strLetter == container[i + 19] || strLetter == container[i + 20]
                        || strLetter == container[i + 21] || strLetter == container[i + 22] || strLetter == container[i + 23] || strLetter == container[i + 24])
                    {



                        char[] arrContainer = container[i].ToCharArray();
                        while (strLetter[i] >= arrContainer[i])
                        {
                            Console.WriteLine("Не сте избрали опция от главното меню: 0 или 1 моля опитайте отново");
                            strLetter = Console.ReadLine().ToLower();
                        }


                        break;
                    }
                }
            }

            do
            {
                Console.WriteLine("Моля  изберете  опция от главното меню: 0 или 1 ако сте го направили потвърдете като повторите избора си ");
                startInput = Int32.Parse(Console.ReadLine());


            } while (startInput != 0 && startInput != 1);
            return startInput;

        }

        public static void PrintMenu()
        {

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "БЕСЕНИЦА"));

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine("Изберете категория в която да играете : ");

            Console.WriteLine("1. Държави");
            Console.WriteLine("2. Градове в България");
            Console.WriteLine("3. Реки в България");
            Console.WriteLine("4. Планини");
            Console.WriteLine("5. Животни");
            Console.WriteLine("6. Растения");
            Console.WriteLine("7. Автомобили (марки/модели)");
            Console.WriteLine("8. Лектори в СофтУни");
            Console.WriteLine("9. Острови");
            Console.WriteLine("10. Планети");
            Console.WriteLine("11. Цветя");


            Console.ResetColor();
        }

        public static bool AddWord()
        {
            bool output = false;
            Console.WriteLine("Изберете категория в която да добавите дума : ");
            Console.WriteLine("1. Държави");
            Console.WriteLine("2. Градове в България");
            Console.WriteLine("3. Реки в България");
            Console.WriteLine("4. Планини");
            Console.WriteLine("5. Животни");
            Console.WriteLine("6. Растения");
            Console.WriteLine("7. Автомобили (марки/модели)");
            Console.WriteLine("8. Лектори в СофтУни");
            Console.WriteLine("9. Острови");
            Console.WriteLine("10. Планети в слънчевата система");
            Console.WriteLine("11. Цветя");
            Console.WriteLine();
            Console.Write("Моля въдедете число от 1 до 11: ");
            int AddToCategory = Int32.Parse(Console.ReadLine()); //category input
            Console.Clear();
            Console.Write("Моля, въведете думата: ");
            string text = Console.ReadLine();
            string pattern = @"\d+";
            //validating words
            Regex matches = new Regex(pattern);
            bool wordConsistDigit = matches.IsMatch(text, 0);
            if (wordConsistDigit)
            {
                Console.WriteLine("Думата не може да съдържа цифри :)");
                Console.Write("Моля, въведи нова дума: ");
                text = Console.ReadLine();

            }

            switch (AddToCategory)
            {
                case 1: string contents = File.ReadAllText(@"Words\Countries.txt");

                    if (contents.Contains(text))
                    {
                        Console.WriteLine("Тази държава вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\Countries.txt", true))
                        {
                            file.WriteLine(text);
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 2: contents = File.ReadAllText(@"Words\City.txt");
                    if (contents.Contains(text))
                    {
                        Console.WriteLine("Този град вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\City.txt", true))
                        {
                            file.WriteLine(text);
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 3: contents = File.ReadAllText(@"Words\Rivers.txt");
                    if (contents.Contains(text))
                    {
                        Console.WriteLine("Тази река вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\Rivers.txt", true))
                        {
                            file.WriteLine(text);
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 4: contents = File.ReadAllText(@"Words\Mountains.txt");
                    if (contents.Contains(text))
                    {
                        Console.WriteLine("Тази планина вече съществува!");
                    }
                    else
                    {

                        using (StreamWriter file = new StreamWriter(@"Words\Mountains.txt", true))
                        {
                            file.WriteLine(text);
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;


                case 5: contents = File.ReadAllText(@"Words\Animals.txt");
                    if (contents.Contains(text))
                    {
                        Console.WriteLine("Това животно вече съществува!");
                    }
                    else
                    {

                        using (StreamWriter file = new StreamWriter(@"Words\Animals.txt", true))
                        {
                            file.WriteLine(text);
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;


                case 6: contents = File.ReadAllText(@"Words\Plants.txt");
                    if (contents.Contains(text))
                    {
                        Console.WriteLine("Това растение вече съществува!");
                    }
                    else
                    {

                        using (StreamWriter file = new StreamWriter(@"Words\Plants.txt", true))
                        {
                            file.WriteLine(text);
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 7: contents = File.ReadAllText(@"Words\Cars.txt");
                    if (contents.Contains(text))
                    {
                        Console.WriteLine("Тази кола вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\Cars.txt", true))
                        {
                            file.WriteLine(text);
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 8: contents = File.ReadAllText(@"Words\Lectors.txt");
                    if (contents.Contains(text))
                    {
                        Console.WriteLine("Този лектор вече съществува");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@" Words\Lectors.txt", true))
                        {
                            file.WriteLine(text);
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 9: contents = File.ReadAllText(@"Words\islands.txt");
                    if (contents.Contains(text))
                    {
                        Console.WriteLine("Този остров вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\islands.txt", true))
                        {
                            file.WriteLine(text);
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;
                case 10: contents = File.ReadAllText(@"Words\planets.txt");
                    if (contents.Contains(text))
                    {
                        Console.WriteLine("Тази планета вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\planets.txt", true))
                        {
                            file.WriteLine(text);
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 12: contents = File.ReadAllText(@"Words\flowers.txt");
                    if (contents.Contains(text))
                    {
                        Console.WriteLine("Това цвете вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\flowers.txt", true))
                        {
                            file.WriteLine(text);
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                default: Console.WriteLine("Wrong Input!"); break;
            }
            Console.WriteLine("Искате ли да въведете друга дума? Да/Не");
            string yN = Console.ReadLine().ToLower();
            if (yN == "да")
            {
                output = true;
            }
            return output;
        }

        public static string RandomWordGen(int category)
        {
            string[][] wordsForTheGame = new string[11][]; //11 strings for 11 categories
            wordsForTheGame[0] = File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Countries.txt"));
            wordsForTheGame[1] = File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\City.txt"));
            wordsForTheGame[2] = File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\River.txt"));
            wordsForTheGame[3] = File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Mountains.txt"));
            wordsForTheGame[4] = File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Animal.txt"));
            wordsForTheGame[5] = File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Plants.txt"));
            wordsForTheGame[6] = File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Cars.txt"));
            wordsForTheGame[7] = File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Lectors.txt"));
            wordsForTheGame[8] = File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\islands.txt"));
            wordsForTheGame[9] = File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\planets.txt"));
            wordsForTheGame[10] = File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\flowers.txt"));

            int numberOfWord = GameMethods.GiveMeRandomNum((int) 0, wordsForTheGame[category].Length - 1); // this is the range of the arrey (0, wordsForTheGame[category].Length - 1)
            return wordsForTheGame[category][numberOfWord].Trim().ToLower();

        }

        public static void GamePlay(string theWotd)
        {
            Console.Clear();
            char[] theWordInArrey = theWotd.ToCharArray();
            char[] hidenWordArrey = new char[theWordInArrey.Length];
            int lettersInWord = 0;
            for (int i = 0; i < theWordInArrey.Length; i++)
            {
                if (theWordInArrey[i] != ' ')
                {
                    hidenWordArrey[i] = '_';
                    lettersInWord++;
                }
                else
                {
                    hidenWordArrey[i] = ' ';
                }
            }
            Console.WriteLine(String.Join(" ", hidenWordArrey));
            Console.Write("Въведете буква:");
            List<string> enterdLetters = new List<string>();
            char letter = Char.Parse(Console.ReadLine());
            enterdLetters.Add(letter.ToString());
            int counterForErrors = 0;
            while (true)
            {
                Console.Clear();
                bool guesLetter = false;
                int howManyLettertAreGuested = 0;
                Console.WriteLine("Въведохте буквите: {0}", String.Join(", ", enterdLetters));
                Console.SetCursorPosition(0, 3);
                for (int i = 0; i < theWordInArrey.Length; i++)
                {
                    if (letter == theWordInArrey[i])
                    {
                        hidenWordArrey[i] = theWordInArrey[i];
                        guesLetter = true;
                    }
                    if (hidenWordArrey[i] == theWordInArrey[i] && hidenWordArrey[i] != ' ')
                    {
                        howManyLettertAreGuested++;
                    }
                }
                if (guesLetter == false)
                {
                    counterForErrors++;
                }
                Console.WriteLine("Остават Ви {0} грешни опита! \n\r", 9 - counterForErrors);
                Console.WriteLine(String.Join(" ", hidenWordArrey));
                Console.WriteLine();
                GameMethods.DrawingGallowAndHangman(counterForErrors);
                if (counterForErrors == 9)
                {
                    Console.WriteLine("GAME OVER!!!");
                    break;
                }
                if (howManyLettertAreGuested == lettersInWord)
                {
                    Console.WriteLine("ЧЕСТИТО!!! СПЕЧЕЛИХТЕ!!!");
                    GameMethods.PlayMusic();
                    break;
                }
                Console.SetCursorPosition(0, 7);
                Console.Write("Въведете буква:");
                letter = Char.Parse(Console.ReadLine());
                enterdLetters.Add(letter.ToString());
            }
        }

        static void Main()
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string doYouWantToPlayAgain;

            do
            {
                Console.Clear();
                int temp = StartMenu(); // say HI and play = 1  or  add word = 0
                if (temp == 1)
                {
                    Console.Clear();
                    PrintMenu(); //topics
                }
                else if (temp == 0) // add word and return to start menu ()
                {
                    bool nextWord = AddWord();
                    while (nextWord)
                    {
                        nextWord = AddWord();
                    }
                }
                int category;
                do
                {
                    category = Int32.Parse(Console.ReadLine());
                    if (category > 11 || category < 1)
                    {
                        Console.WriteLine("Enter number from 1 to 11!!!");
                    }

                } while (category != 1 && category != 2 && category != 3 && category != 4 &&
                                category != 5 && category != 6 && category != 7 && category != 8 && category != 9 && category != 10 && category != 11);



                string theWord = RandomWordGen(category - 1); // random word for hangman 
                GamePlay(theWord);                            // guess the word 


                Console.WriteLine("Do you want to play again? Y/N");
                do
                {
                    doYouWantToPlayAgain = Console.ReadLine().ToLower();
                    if (doYouWantToPlayAgain != "n" && doYouWantToPlayAgain != "y")
                    {
                        Console.WriteLine("Do you want to play again? Return to Main Menu: Y/N");
                    }
                } while (doYouWantToPlayAgain != "y" && doYouWantToPlayAgain != "y");


            } while (doYouWantToPlayAgain == "y");

        }
    }
}



