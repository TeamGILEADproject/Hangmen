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
        static void Main()
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string doYouWantToPlayAgain;

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
                }
                string categoryStr;
                int category;
                do
                {
                    categoryStr = Console.ReadLine();
                    if (!GameMethods.IsValidNum1_11(categoryStr))
                    {
                        Console.WriteLine("Въведете число от 1 до 11:");
                    }

                } while (!GameMethods.IsValidNum1_11(categoryStr));
                category = int.Parse(categoryStr);


                string theWord = GameMethods.RandomWordGen(category - 1); // random word for hangman 
                GameMethods.GamePlay(theWord);                            // guess the word 


                Console.WriteLine("Нова игра? Д/Н");
                do
                {
                    doYouWantToPlayAgain = Console.ReadLine().ToLower();
                    if (doYouWantToPlayAgain != "н" && doYouWantToPlayAgain != "д")
                    {
                        Console.WriteLine("Нова игра? Връщане в главно меню? Д/Н");
                    }
                } while (doYouWantToPlayAgain != "н" && doYouWantToPlayAgain != "д");


            } while (doYouWantToPlayAgain == "д");

        }

    }
}