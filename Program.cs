using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.DesignerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Main___
{
    class Program
    {
        static void Main()
        {

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture; 
            Console.InputEncoding = Encoding.Unicode; 
            Console.OutputEncoding = Encoding.Unicode;
            string doYouWantToPlayAgain;

            do
            {
                int temp = StartMenu(); // say HI and play = 1  or  add word = 0
                if (temp == 1)
                {
                    PrintMenu(); //topics
                }
                else if (temp == 0) 
                {
                    AddWord(); // add word and return to start menu ()
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
            Console.WriteLine("БЕСЕНИЦА /n/r created by Team GILEAD");
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

            Console.WriteLine("Изберете дума, с която да играете  от следните категории : ");

            Console.WriteLine("1. Държави");
            Console.WriteLine("2. Градове в България");
            Console.WriteLine("3. Реки в България");
            Console.WriteLine("4. Планини");
            Console.WriteLine("5. Животни");
            Console.WriteLine("6. Растения");
            Console.WriteLine("7. Автомобили (марки/модели)");
            Console.WriteLine("8. Лектори в СофтУни");

            Console.ResetColor();


        }




    }
}
