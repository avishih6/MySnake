using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;

namespace Snake
{
    class TheSnake : GamePart
    {
        private List<Pixel> m_body;

        public TheSnake(int? X, int? Y, ConsoleColor Color = ConsoleColor.Red) : 
        base(X.HasValue ? X.Value : WindowWidth/2, Y.HasValue ? Y.Value : WindowHeight/2, Color)
        {           
            m_body = new List<Pixel>();
        }
        private void DrawHead()
        {
            Pixel.DrawPixel(Head);
        }

        private void DrawBody(ref bool gameOver)
        {
            for (int i = 0; i < Body.Count; i++)
            {
                Pixel.DrawPixel (Body[i]);
                gameOver |= (Body[i].XPos == Head.XPos && Body[i].YPos == Head.YPos);
            }
        }

        public void DrawSnake(ref bool gameOver){
            DrawHead();
            DrawBody(ref gameOver);
        }

        private static Direction ReadSnakeMovement (Direction movement)
        {
            if (KeyAvailable)
            {
                var key = ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow && movement != Direction.Down)
                {
                    movement = Direction.Up;
                }
                else if (key == ConsoleKey.DownArrow && movement != Direction.Up)
                {
                    movement = Direction.Down;
                }
                else if (key == ConsoleKey.LeftArrow && movement != Direction.Right)
                {
                    movement = Direction.Left;
                }
                else if (key == ConsoleKey.RightArrow && movement != Direction.Left)
                {
                    movement = Direction.Right;
                }
            }

            return movement;
        }

        public Pixel setNewBodyPartLocation(Direction movementDir, Pixel tailLocation)
        {   
            Pixel location = new Pixel(tailLocation.XPos, tailLocation.YPos, ConsoleColor.Green);
            switch (movementDir)
            {
                case Direction.Up:
                    location = new Pixel(tailLocation.XPos, tailLocation.YPos - 1, ConsoleColor.Green);
                    break;
                case Direction.Down:
                    location = new Pixel(tailLocation.XPos, tailLocation.YPos + 1, ConsoleColor.Green);
                    break;
                case Direction.Left:
                    location = new Pixel(tailLocation.XPos + 1, tailLocation.YPos, ConsoleColor.Green);
                    break;
                case Direction.Right:
                    location = new Pixel(tailLocation.XPos - 1, tailLocation.YPos, ConsoleColor.Green);
                    break;
            }
            return location;
        }

        public void Move(ref Direction currentMovement){
            var sw = Stopwatch.StartNew();
            int headPrevX = Head.XPos, headPrevY = Head.YPos;
            while (sw.ElapsedMilliseconds <= 500)
            {
                currentMovement = ReadSnakeMovement(currentMovement);
            } 
               
            switch (currentMovement)
            {
                case Direction.Up:                    
                    Head.YPos--;
                    break;
                case Direction.Down:
                    Head.YPos++;
                    break;
                case Direction.Left:
                    Head.XPos--;
                    break;
                case Direction.Right:
                    Head.XPos++;
                    break;
            }
            MoveBody(headPrevX, headPrevY);
        }

        private void MoveBody(int headPrevX, int headPrevY){
            int prevX=0, prevY=0;
            int tmp1, tmp2;
            for(int i=0; i<Body.Count; i++)
            { 
                if(i==0){
                    prevX = Body[i].XPos;
                    prevY = Body[i].YPos;

                    Body[i].XPos = headPrevX;
                    Body[i].YPos = headPrevY; 
                }
                else{
                    tmp1 = Body[i].XPos;
                    tmp2 = Body[i].YPos;

                    Body[i].XPos = prevX;
                    Body[i].YPos = prevY;

                    prevX = tmp1;
                    prevY = tmp2;
                }   
            }
        }

        public Pixel Head{
            get{return Position;}
            set{Position = value;}
        }

        public List<Pixel> Body{
            get{return m_body;}
            set{m_body = value;}
        }
    }
}