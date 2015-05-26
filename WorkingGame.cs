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



                string theWord = GameMethods.RandomWordGen(category - 1); // random word for hangman 
                GameMethods.GamePlay(theWord);                            // guess the word 


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



