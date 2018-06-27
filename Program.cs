using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;

namespace Snake
{
    class Program
    {
        static void Main ()
        {            
            var score = 0;
            
            SetWindowSize(32, 16);

            var borderManager = new BorderManager(WindowWidth, WindowHeight);

            var snake = new TheSnake(null, null, ConsoleColor.Red);           

            var berryManager = new BerryManager(WindowWidth, WindowHeight);          

            var currentMovement = Direction.Right;

            var gameOver = false;

            while (true)
            {
                Clear();

                gameOver |= (snake.Head.XPos == WindowWidth - 1 || snake.Head.XPos == 0 || snake.Head.YPos == WindowHeight - 1 || snake.Head.YPos == 0);

                borderManager.DrawBorder();
                
                berryManager.CheckIfScoreShouldBeInc(snake, currentMovement, ref score);
                
                snake.DrawSnake(ref gameOver);

                if (gameOver)
                {
                    break;
                }                

                berryManager.DrawBerry();           

                snake.Move(ref currentMovement);
            }
            SetCursorPosition (WindowWidth / 5, WindowHeight / 2);
            WriteLine ($"Game over, Score: {score}");
            SetCursorPosition (WindowWidth / 5, WindowHeight / 2 + 1);
            ReadKey ();
        }
    }
}
