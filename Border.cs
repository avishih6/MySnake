using System;
using static System.Console;
using System.Collections.Generic;

namespace Snake
{
    class Border : GamePart
    {
        private List<Pixel> m_borderPixels;
        public Border(ConsoleColor color = ConsoleColor.White) : base(0, 0, color) => m_borderPixels = new List<Pixel>();

        public List<Pixel> BorderPixels
        {
            get{return m_borderPixels;}
            set{m_borderPixels = value;}
        }
    }
}