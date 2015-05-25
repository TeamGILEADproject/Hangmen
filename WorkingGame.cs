using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WorkingGame
{
    class WorkingGame
    {
        static void Main()
        {

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
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
                    category = int.Parse(Console.ReadLine());
                    if (category > 8 || category < 1)
                    {
                        Console.WriteLine("Enter number from 1 to 8!!!");
                    }

                } while (category != 1 && category != 2 && category != 3 && category != 4 &&
                                category != 5 && category != 6 && category != 7 && category != 8);



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


        public static int StartMenu()
        {
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "БЕСЕНИЦА"));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "created by Team GILEAD"));
            Console.WriteLine("За игра въведете 1");
            Console.WriteLine("За да въведете нова дума въведете 0");
            int startInput;
            do
            {
                startInput = int.Parse(Console.ReadLine());
                if (startInput != 0 && startInput != 1)
                {
                    Console.WriteLine("Моля изберете опция от главното меню: 0 или 1");
                }

            } while (startInput != 0 && startInput != 1);
            return startInput;
        }




        static void PrintMenu()
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

        public static string RandomWordGen(int category)
        {
            string[][] wordsForTheGame = new string[8][]; //8 strings for 8 categories
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
            
            int numberOfWord = GiveMeRandomNum(0, wordsForTheGame[category].Length - 1); // this is the range of the arrey (0, wordsForTheGame[category].Length - 1)
            return wordsForTheGame[category][numberOfWord].Trim().ToLower();

        }

        public static int GiveMeRandomNum(int min, int max) //return random num in range min, max
        {
            Random random = new Random();
            int myRandomNum = random.Next(min, max);
            return myRandomNum;
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
            int AddToCategory = int.Parse(Console.ReadLine()); //category input
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
            Console.WriteLine(string.Join(" ", hidenWordArrey));
            Console.WriteLine("Въведете буква:");
            List<string> enterdLetters = new List<string>();
            char letter = Char.Parse(Console.ReadLine());
            enterdLetters.Add(letter.ToString());
            int counterForErrors = 0;
            while (true)
            {
                Console.Clear();
                bool guesLetter = false;
                int howManyLettertAreGuested = 0;
                Console.WriteLine("Въведохте буквите: {0}", string.Join(", ", enterdLetters));
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
                Console.WriteLine(string.Join(" ", hidenWordArrey));
                Console.WriteLine();
                DrawingGallowAndHangman(counterForErrors);
                if (counterForErrors == 9)
                {
                    Console.WriteLine("GAME OVER!!!");
                    break;
                }
                if (howManyLettertAreGuested == lettersInWord)
                {
                    Console.WriteLine("ЧЕСТИТО!!! СПЕЧЕЛИХТЕ!!!");
                    PlayMusic();
                    break;
                }
                Console.SetCursorPosition(0,7);
                Console.WriteLine("Въведете буква:");
                letter = Char.Parse(Console.ReadLine());
                enterdLetters.Add(letter.ToString());
            }
        }


        public static void PlayMusic()
        {
            Console.Beep(658, 125); Console.Beep(1320, 500); Console.Beep(990, 250);
            Console.Beep(1056, 250); Console.Beep(1188, 250); Console.Beep(1320, 125);
            Console.Beep(1188, 125); Console.Beep(1056, 250); Console.Beep(990, 250);
            Console.Beep(880, 500); Console.Beep(880, 250); Console.Beep(1056, 250);
            Console.Beep(1320, 500); Console.Beep(1188, 250); Console.Beep(1056, 250);
            Console.Beep(990, 750); Console.Beep(1056, 250); Console.Beep(1188, 500);
            Console.Beep(1320, 500); Console.Beep(1056, 500); Console.Beep(880, 500);
            Console.Beep(880, 500);
        }

        public static void DrawFrame() //drawning frame
        {
            int frameWidth = 36;
            int frameHeight = 27;
            Console.SetCursorPosition(50, 2);
            Console.Write(new string('-', frameWidth + 2));
            for (int i = 3; i < frameHeight; i++)
            {
                Console.SetCursorPosition(50, i);
                Console.WriteLine(new string('|', 1) + new string(' ', frameWidth) + new string('|', 1));
            }
            Console.SetCursorPosition(50, 27);
            Console.Write(new string('-', frameWidth + 2));
        }
        static int baseGallowWidth = 11;
        static int ropeHeight = 8;
        static int gallowTopBaseWidth = 15;

        public static void DrawingGallowBase()
        {
            Console.SetBufferSize(90, 31);
            Console.SetCursorPosition(53, 25);
            //draw base gallow
            Console.Write(new string('_', baseGallowWidth));
            for (int i = 25; i > 4; i--)
            {
                Console.SetCursorPosition(58, i);
                Console.Write("|");
            }
        }

        public static void DrawingTopBaseAndRope()
        {
            //draw Top Base and rope
            Console.SetCursorPosition(58, 4);
            Console.WriteLine(new string('-', gallowTopBaseWidth));
            //draw rope
            for (int row = 5; row < ropeHeight; row++)
            {
                Console.SetCursorPosition(72, row);
                Console.WriteLine('|');
            }
        }

        static int legsHeight = 4;
        static int startingColLeg = 71;
        static int armHeight = 4;
        static int startingColArm = 71;
        static int bodyHeight = 7;
        public static void DrawingHead()
        {
            Console.SetCursorPosition(70, 9);
            Console.WriteLine("-----");
            Console.SetCursorPosition(69, 10);
            Console.WriteLine("( - - )");
            Console.SetCursorPosition(69, 11);
            Console.WriteLine("|  -  |");
            Console.SetCursorPosition(70, 12);
            Console.WriteLine("-----");
        }

        public static void DrawingBody(int startRow)
        {
            for (int i = startRow; i < bodyHeight + startRow; i++)
            {
                Console.SetCursorPosition(72, i);
                Console.WriteLine("|");
            }
        }

        public static void DrawingLeftLeg(int startRow)
        {
            startingColLeg = 71;
            for (int i = startRow; i < legsHeight + startRow; i++)
            {
                Console.SetCursorPosition(startingColLeg, i);
                Console.WriteLine("/");
                startingColLeg--;
            }
        }

        public static void DrawingRightLeg(int startRow)
        {
            startingColLeg = 73;
            for (int i = startRow; i < legsHeight + startRow; i++)
            {
                Console.SetCursorPosition(startingColLeg, i);
                Console.WriteLine(@"\");
                startingColLeg++;
            }
        }

        public static void DrawingLeftArm(int startRow)
        {
            startingColArm = 71;
            for (int i = startRow; i > startRow - armHeight; i--)
            {
                Console.SetCursorPosition(startingColArm, i);
                Console.WriteLine(@"\");
                startingColArm--;
            }
        }

        public static void DrawingRightArmAndMessage(int starRow)
        {
            startingColArm = 73;
            for (int i = starRow; i > starRow - armHeight; i--)
            {
                Console.SetCursorPosition(startingColArm, i);
                Console.WriteLine("/");
                startingColArm++;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(77, 7);
            Console.WriteLine("Please,");
            Console.SetCursorPosition(77, 8);
            Console.WriteLine("don`t make");
            Console.SetCursorPosition(77, 9);
            Console.WriteLine("mistake");
            Console.SetCursorPosition(77, 10);
            Console.WriteLine("again!!!");
        }

        public static void HangMan()
        {
            DrawingHead();
            Console.SetCursorPosition(70,13);
            Console.WriteLine("         ");
            Console.SetCursorPosition(70, 14);
            Console.WriteLine("         ");
            DrawingBody(15);
            DrawingLeftLeg(22);
            DrawingRightLeg(22);
            DrawingLeftArm(18);
            DrawingRightArmAndMessage(18);

        }
        public static void DrawingGallowAndHangman(int countFalsePrediction)
        {
            DrawFrame();
            switch (countFalsePrediction)
            {
                case 1:
                {
                    DrawingGallowBase();
                    break;
                }
                case 2:
                {
                    DrawingGallowBase();
                    DrawingTopBaseAndRope();
                    break;
                }
                case 3:
                {
                    DrawingGallowBase();
                    DrawingTopBaseAndRope();
                    DrawingHead();
                    break;
                }
                case 4:
                {
                    DrawingGallowBase();
                    DrawingTopBaseAndRope();
                    DrawingHead();
                    DrawingBody(13);
                    break;
                }
                case 5:
                {
                    DrawingGallowBase();
                    DrawingTopBaseAndRope();
                    DrawingHead();
                    DrawingBody(13);
                    DrawingLeftLeg(20);
                    break;
                }
                case 6:
                {
                    DrawingGallowBase();
                    DrawingTopBaseAndRope();
                    DrawingHead();
                    DrawingBody(13);
                    DrawingLeftLeg(20);
                    DrawingRightLeg(20);
                    break;
                }
                case 7:
                {
                    DrawingGallowBase();
                    DrawingTopBaseAndRope();
                    DrawingHead();
                    DrawingBody(13);
                    DrawingLeftLeg(20);
                    DrawingRightLeg(20);
                    DrawingLeftArm(16);
                    break;
                }
                case 8:
                {
                    DrawingGallowBase();
                    DrawingTopBaseAndRope();
                    DrawingHead();
                    DrawingBody(13);
                    DrawingLeftLeg(20);
                    DrawingRightLeg(20);
                    DrawingLeftArm(16);
                    DrawingRightArmAndMessage(16);
                    break;
                }
                case 9:
                {
                    DrawingGallowBase();
                    DrawingTopBaseAndRope(); 
                    HangMan();
                    break;
                }
            }
        }
    }
}


