using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintMenu
{
    class PrintingMenu
    {
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
            Console.WriteLine("9. Острови");
            Console.WriteLine("10. Планети");
            Console.WriteLine("11. Цветя");

            Console.ResetColor();


        }
        static void Main()
        {
          PrintMenu();
           
        }
    }
}
