using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkingGame
{
    public static class GameMethods
    {
        
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
            Console.WriteLine("Please,");
            Console.SetCursorPosition(77, 8);
            Console.WriteLine("don`t make");
            Console.SetCursorPosition(77, 9);
            Console.WriteLine("mistake");
            Console.SetCursorPosition(77, 10);
            Console.WriteLine("again!!!");
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
