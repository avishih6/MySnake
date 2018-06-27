using System;
using static System.Console;

namespace Snake
{
    class Pixel
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public ConsoleColor ScreenColor { get; set; }
        public Pixel (int xPos, int yPos, ConsoleColor color = ConsoleColor.White)
        {
            XPos = xPos;
            YPos = yPos;
            ScreenColor = color;
        }

        public static void DrawPixel (Pixel pixel)
        {
            SetCursorPosition(pixel.XPos, pixel.YPos);
            ForegroundColor = pixel.ScreenColor;
            Write ("■");
        }
    }
}