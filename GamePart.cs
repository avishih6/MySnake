using System;
using static System.Console;

namespace Snake
{
    /// <summary>
    /// Represents a graphical unit of the game
    /// </summary>
    class GamePart
    { 
        private Pixel m_position;

        public GamePart(int X, int Y, ConsoleColor Color = ConsoleColor.White)
        {
            m_position = new Pixel(X, Y, Color);            
        }

        public Pixel Position 
        {
            get{return m_position;}
            set{m_position = value;}
        }
    }
}