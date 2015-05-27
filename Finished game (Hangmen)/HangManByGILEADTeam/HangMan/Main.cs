﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HangMan
{
    public class WorkingGame
    {

        static void Main()
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 90;
            Console.BufferHeight = 30;
            Console.BufferWidth = 90;


            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string doYouWantToPlayAgain = "д";

            do
            {
                Console.Clear();
                int temp = GameMethods.StartMenu(); // say HI and play = 1  or  add word = 0
                if (temp == 1)
                {
                    Console.Clear();
                    GameMethods.PrintMenu(); //topics
                }
                else if (temp == 0) // add word and return to start menu ()
                {
                    bool nextWord = GameMethods.AddWord();
                    while (nextWord)
                    {
                        nextWord = GameMethods.AddWord();
                    }
                    continue;
                }
                string categoryStr;
                int category;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Въведете число от 1 до 11: ");
                do
                {
                    categoryStr = Console.ReadLine();
                    if (!GameMethods.IsValidNum1_11(categoryStr))
                    {
                        Console.Write("Въведете число от 1 до 11: ");
                    }

                } while (!GameMethods.IsValidNum1_11(categoryStr));
                category = int.Parse(categoryStr);


                string theWord = GameMethods.RandomWordGen(category - 1); // random word for hangman 
                GameMethods.GamePlay(theWord, category);                            // guess the word 

                Console.ResetColor();
                Console.SetCursorPosition(23, 16);
                Console.WriteLine("Нова игра? Д/Н");
                do
                {
                    doYouWantToPlayAgain = Console.ReadLine().ToLower();
                    if (doYouWantToPlayAgain != "н" && doYouWantToPlayAgain != "д")
                    {
                        Console.SetCursorPosition(12, 17);
                        Console.WriteLine("Нова игра? Връщане в главно меню? Д/Н");
                    }
                } while (doYouWantToPlayAgain != "н" && doYouWantToPlayAgain != "д");


            } while (doYouWantToPlayAgain == "д");

        }

    }
}