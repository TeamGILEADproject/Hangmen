using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace RandomGenWord
{
    class RandomGenWord
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture; //!!!
            Console.InputEncoding = Encoding.Unicode; //!!!
            Console.OutputEncoding = Encoding.Unicode; //!!!
            int testCategory = int.Parse(Console.ReadLine()); //category input
            string word = RandomWordGen(testCategory-1); // word for hangman 
            Console.WriteLine(word); //test
        }

        public static string RandomWordGen(int category)
        {
            string [][] wordsForTheGame = new string[8][]; //8 strings for 8 categories
            wordsForTheGame[0] = System.IO.File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Countries.txt"));
            wordsForTheGame[1] = System.IO.File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\City.txt")); 
            wordsForTheGame[2] = System.IO.File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\River.txt"));
            wordsForTheGame[3] = System.IO.File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Mountains.txt")); 
            wordsForTheGame[4] = System.IO.File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Animal.txt"));
            wordsForTheGame[5] = System.IO.File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Plants.txt"));
            wordsForTheGame[6] = System.IO.File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Cars.txt"));
            wordsForTheGame[7] = System.IO.File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\Lectors.txt"));
            wordsForTheGame[8] = System.IO.File.ReadAllLines
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\islands.txt"));
            wordsForTheGame[9] = System.IO.File.ReadAllLines
               (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Words\planets.txt"));
            wordsForTheGame[10] = System.IO.File.ReadAllLines
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
    }
}
