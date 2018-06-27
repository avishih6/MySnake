using System;
using static System.Console;

namespace Snake
{
    class BerryManager
    {
        private static Random rand = new Random();
        private static Berry m_berry;       
        private int m_windowWidth;
        private int m_windowHeight;

        public BerryManager(int windowWidth, int windowHeight)
        {
            m_windowWidth = windowWidth;
            m_windowHeight = windowHeight;

            setBerryOnRandLocation();
        }

        public void DrawBerry()
        {            
            Pixel.DrawPixel(m_berry.Position);
        }

        public void setBerryOnRandLocation() => m_berry = new Berry(rand.Next(1, m_windowWidth - 2), rand.Next(1, m_windowHeight - 2), ConsoleColor.Magenta);

        public void CheckIfScoreShouldBeInc(TheSnake snake, Direction movementDir, ref int score){
            if (m_berry.Position.XPos == snake.Head.XPos && m_berry.Position.YPos == snake.Head.YPos)
            {
                score++;
                Pixel newBodyPartLocation;
                if(snake.Body.Count > 0){                
                    newBodyPartLocation = snake.setNewBodyPartLocation(movementDir, snake.Body[snake.Body.Count -1]);
                }
                else{
                    newBodyPartLocation = snake.setNewBodyPartLocation(movementDir, snake.Head);
                }
                snake.Body.Add(newBodyPartLocation);
                setBerryOnRandLocation();
            }
        }

        public static Berry Berry{
            get{return m_berry;}            
        }
    }
}