using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkingGame
{
    public class GameMethods
    {
        public static int StartMenu()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();

            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "БЕСЕНИЦА"));

            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine();

            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 3);
            Console.WriteLine("created by Team GILEAD");
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("0. Въведете нова дума");
            Console.WriteLine();
            Console.WriteLine("1. ИГРАЙ!");
            Console.WriteLine();



            int startInput = 1;
            string strLetter;

            do
            {
                Console.Write("Моля, въведете 0 или 1: ");
                strLetter = Console.ReadLine();
                if (IsValidNum01(strLetter))
                {
                    startInput = int.Parse(strLetter);
                }

            } while (!IsValidNum01(strLetter));

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
            Console.Clear();
            bool output = false;
            string[] categories = new[]
            {
                "",
                "Държави",
                "Градове в България",
                "Реки в България",
                "Планини",
                "Животни",
                "Растения",
                "Автомобили (марки/модели)",
                "Лектори в СофтУни",
                "Острови",
                "Планети",
                "Цветя"

            };
            Console.ForegroundColor = ConsoleColor.DarkCyan;
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
            Console.WriteLine("10. Планети");
            Console.WriteLine("11. Цветя");
            Console.WriteLine();
            Console.Write("Моля въдедете число от 1 до 11: ");

            int AddToCategory = int.Parse(Console.ReadLine());//category input
            while (AddToCategory < 1 || AddToCategory > 11)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Моля въдедете число от 1 до 11: ");
                AddToCategory = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Избраната от вас категория е: {0}", categories[AddToCategory]);
            Console.Write("Моля, въведете думата: ");
            string text = Console.ReadLine().ToLower();
            string pattern = @"\d+";
            //validating words
            Regex matches = new Regex(pattern);
            bool wordConsistDigit = matches.IsMatch(text, 0);
            if (wordConsistDigit)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Думата не може да съдържа цифри :)");
                Console.Write("Моля, въведи нова дума: ");
                text = Console.ReadLine().ToLower();

            }

            switch (AddToCategory)
            {

                case 1: string contents = File.ReadAllText(@"Words\Countries.txt");

                    if (contents.Contains(text))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;


                        Console.WriteLine("Тази държава вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\Countries.txt", true))
                        {
                            file.WriteLine(text);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 2: contents = File.ReadAllText(@"Words\City.txt");
                    if (contents.Contains(text))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Този град вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\City.txt", true))
                        {
                            file.WriteLine(text);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 3: contents = File.ReadAllText(@"Words\Rivers.txt");
                    if (contents.Contains(text))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Тази река вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\Rivers.txt", true))
                        {
                            file.WriteLine(text);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 4: contents = File.ReadAllText(@"Words\Mountains.txt");
                    if (contents.Contains(text))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Тази планина вече съществува!");
                    }
                    else
                    {

                        using (StreamWriter file = new StreamWriter(@"Words\Mountains.txt", true))
                        {
                            file.WriteLine(text);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;


                case 5: contents = File.ReadAllText(@"Words\Animals.txt");
                    if (contents.Contains(text))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Това животно вече съществува!");
                    }
                    else
                    {

                        using (StreamWriter file = new StreamWriter(@"Words\Animals.txt", true))
                        {
                            file.WriteLine(text);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;


                case 6: contents = File.ReadAllText(@"Words\Plants.txt");
                    if (contents.Contains(text))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Това растение вече съществува!");
                    }
                    else
                    {

                        using (StreamWriter file = new StreamWriter(@"Words\Plants.txt", true))
                        {
                            file.WriteLine(text);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 7: contents = File.ReadAllText(@"Words\Cars.txt");
                    if (contents.Contains(text))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Тази кола вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\Cars.txt", true))
                        {
                            file.WriteLine(text);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 8: contents = File.ReadAllText(@"Words\Lectors.txt");
                    if (contents.Contains(text))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Този лектор вече съществува");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@" Words\Lectors.txt", true))
                        {
                            file.WriteLine(text);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 9: contents = File.ReadAllText(@"Words\islands.txt");
                    if (contents.Contains(text))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Този остров вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\islands.txt", true))
                        {
                            file.WriteLine(text);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;
                case 10: contents = File.ReadAllText(@"Words\planets.txt");
                    if (contents.Contains(text))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Тази планета вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\planets.txt", true))
                        {
                            file.WriteLine(text);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                case 11: contents = File.ReadAllText(@"Words\flowers.txt");
                    if (contents.Contains(text))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Това цвете вече съществува!");
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@"Words\flowers.txt", true))
                        {
                            file.WriteLine(text);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Думата беше въведена. Благодарим ти!");
                            file.Close();
                        }
                    } break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Грешен вход!"); break;
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
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

            int numberOfWord = GameMethods.GiveMeRandomNum((int)0, wordsForTheGame[category].Length - 1); // this is the range of the arrey (0, wordsForTheGame[category].Length - 1)
            return wordsForTheGame[category][numberOfWord].Trim().ToLower();

        }

        public static void GamePlay(string theWord, int category)
        {
            Console.Clear();
            string[] cetegoryStrMass =       {  "Държави",
                                                "Градове в България",
                                                "Реки в България",
                                                "Планини",
                                                "Животни",
                                                "Растения",
                                                "Автомобили (марки/модели)",
                                                "Лектори в СофтУни",
                                                "Острови",
                                                "Планети",
                                                "Цветя"        };
            char[] theWordInArrey = theWord.ToCharArray();
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
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(String.Join(" ", hidenWordArrey));
            Console.Write("Въведете буква: ");
            List<string> enterdLetters = new List<string>();
            string letter = Console.ReadLine();
            //added validation for input letter
            while (letter.Length > 1 || letter == " " || letter == String.Empty)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Моля, въведете само една буква :)");
                Console.Write("Въведете буква: ");
                letter = Console.ReadLine();
            }
            while (!GameMethods.IsValidLetter(letter))
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Моля, въведете буква от А до Я.");
                Console.Write("Въведете буква: ");
                letter = Console.ReadLine();
            }
            enterdLetters.Add(letter);
            int counterForErrors = 0;
            while (true)
            {
                Console.Clear();
                bool guesLetter = false;
                int howManyLettertAreGuested = 0;
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Категория: {0}", cetegoryStrMass[category - 1]);
                Console.SetCursorPosition(0, 2);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Въведохте буквите: \n\r{0}", String.Join(", ", enterdLetters));
                for (int i = 0; i < theWordInArrey.Length; i++)
                {
                    char currentEnteredChar = Convert.ToChar(letter);
                    if (currentEnteredChar == theWordInArrey[i])
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
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Остават Ви {0} грешни опита! \n\r", 9 - counterForErrors);
                Console.WriteLine(String.Join(" ", hidenWordArrey));
                Console.WriteLine();
                GameMethods.DrawingGallowAndHangman(counterForErrors);
                if (counterForErrors == 9)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("Играта свърши!!! Обесени сте!!!!");
                    break;
                }
                if (howManyLettertAreGuested == lettersInWord)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(20,15);
                    Console.WriteLine("ЧЕСТИТО!!! СПЕЧЕЛИ!!!");
                    GameMethods.PlayMusic();
                    break;
                }
                Console.SetCursorPosition(0, 8);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Въведете буква: ");
                letter = Console.ReadLine();
                //added validation for input letter
                while (letter.Length > 1 || letter == " " || letter == String.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Моля, въведете само една буква :)");
                    Console.Write("Въведете буква: ");
                    letter = Console.ReadLine();
                }
                while (!GameMethods.IsValidLetter(letter))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Моля, въведете буква от А до Я.");
                    Console.Write("Въведете буква: ");
                    letter = Console.ReadLine();
                }

                enterdLetters.Add(letter);
            }
        }

        public static bool IsValidLetter(string letter)
        {
            char currentChar = char.Parse(letter.ToLower());
            if (char.IsDigit(currentChar) || (currentChar >= 'a' && currentChar <= 'z'))
            {
                return false;
            }


            return true;
        }
        public static bool IsValidNum01(string letter)
        {
            if (letter == String.Empty)
            {
                return false;
            }
            if (letter != "0" && letter != "1")
            {
                return false;
            }


            return true;
        }
        public static bool IsValidNum1_11(string numberStr)
        {
            if (numberStr == String.Empty)
            {
                return false;
            }
            if (numberStr != "1" && numberStr != "2" && numberStr != "3" && numberStr != "4" && numberStr != "5" &&
                    numberStr != "6" && numberStr != "7" && numberStr != "8" && numberStr != "9" && numberStr != "10" &&
                    numberStr != "11")
            {
                return false;
            }
            return true;
        }

        public static int GiveMeRandomNum(int min, int max) //return random num in range min, max
        {
            Random random = new Random();
            int myRandomNum = random.Next(min, max);
            return myRandomNum;
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
            Console.WriteLine("Моля,");
            Console.SetCursorPosition(77, 8);
            Console.WriteLine("не правете");
            Console.SetCursorPosition(77, 9);
            Console.WriteLine("повече");
            Console.SetCursorPosition(77, 10);
            Console.WriteLine("грешки!!!");
            Console.ResetColor();
        }

        public static void HangMan()
        {
            DrawingHead();
            Console.SetCursorPosition(70, 13);
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
