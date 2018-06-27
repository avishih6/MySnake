using System;
using static System.Console;
using System.Collections.Generic;

namespace Snake
{
    class BorderManager
    {
        private int m_windowWidth;
        private int m_windowHeight;
        private Border m_border;

        public BorderManager(int windowWidth, int windowHeight){
            m_windowWidth = windowWidth;
            m_windowHeight = windowHeight;

            m_border = new Border();

            for (int i = 0; i < m_windowWidth; i++)
            {
                m_border.BorderPixels.Add(new Pixel(i, 0));
                m_border.BorderPixels.Add(new Pixel(i, m_windowHeight - 1));
            }

            for (int i = 0; i < WindowHeight; i++)
            {
                m_border.BorderPixels.Add(new Pixel(0, i));
                m_border.BorderPixels.Add(new Pixel(WindowWidth - 1, i));
            }
        }

        public void DrawBorder()
        {
            for(int i=0; i<m_border.BorderPixels.Count;i++){
               Pixel.DrawPixel(m_border.BorderPixels[i]);
            }
        }
    }
}