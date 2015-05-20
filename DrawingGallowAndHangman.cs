using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
 
namespace DrawingGallowsAndHangman
{
    class DrawingGallowsAndHangman
    {
        static void Main()
        {
            DrawFrame();
            DrawingGallow(2);
            DrawMen(3);
        }
 
        public static void DrawFrame()
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
        public static void DrawingGallow(int countFalsePrediction)
        {
            int baseGallowWidth = 11;
            int gallowTopBaseWidth = 15;
            int ropeHeight = 8;
            Console.SetBufferSize(90, 31);
            Console.SetCursorPosition(53, 25);
            //draw base gallow
            //if (countFalsePrediction == 1)
            //{
                Console.Write(new string('_', baseGallowWidth));
                for (int i = 25; i > 4; i--)
                {
                    Console.SetCursorPosition(58, i);
                    Console.Write("|");
                }
            //}
 
            //if (countFalsePrediction == 2)
            //{
                //draw Top Base and rope
                Console.SetCursorPosition(58, 4);
                Console.WriteLine(new string('-', gallowTopBaseWidth));
                //draw rope
                for (int row = 5; row < ropeHeight; row++)
                {
                    Console.SetCursorPosition(72, row);
                    Console.WriteLine('|');
                }
            //}
           
        }
 
        public static void DrawMen(int countFalsePrediction)
        {
 
            int legsHeight = 4;
            int startingColLeg = 71;
            int armHeight = 4;
            int startingColArm = 71;
            // draw head
            //if (countFalsePrediction == 3)
            //{
                Console.SetCursorPosition(70, 9);
                Console.WriteLine("-----");
                Console.SetCursorPosition(69, 10);
                Console.WriteLine("( - - )");
                Console.SetCursorPosition(69, 11);
                Console.WriteLine("|  -  |");
                Console.SetCursorPosition(70, 12);
                Console.WriteLine("-----");
            //}
            //else if (countFalsePrediction == 4)
            //{
                //draw body
                int bodyHeight = 7;
                for (int i = 13; i < bodyHeight + 13; i++)
                {
                    Console.SetCursorPosition(72, i);
                    Console.WriteLine("|");
                }
            //}
            //else if (countFalsePrediction == 5)
            //{
                // draw left leg
 
               
                for (int i = 20; i < legsHeight + 20; i++)
                {
                    Console.SetCursorPosition(startingColLeg, i);
                    Console.WriteLine("/");
                    startingColLeg--;
                }
            //}
            //else if (countFalsePrediction == 6)
            //{
                // draw right leg
 
                startingColLeg = 73;
                for (int i = 20; i < legsHeight + 20; i++)
                {
                    Console.SetCursorPosition(startingColLeg, i);
                    Console.WriteLine(@"\");
                    startingColLeg++;
                }
            //}
            //else if (countFalsePrediction == 7)
            //{
                // draw left arm
               
                for (int i = 16; i > 16 - armHeight; i--)
                {
                    Console.SetCursorPosition(startingColArm, i);
                    Console.WriteLine(@"\");
                    startingColArm--;
                }
            //}
            //else if (countFalsePrediction == 8)
            //{
                // draw right arm
                startingColArm = 73;
                for (int i = 16; i > 16 - armHeight; i--)
                {
                    Console.SetCursorPosition(startingColArm, i);
                    Console.WriteLine("/");
                    startingColArm++;
                }
            //}
        }
    }
}