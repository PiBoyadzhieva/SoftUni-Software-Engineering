using System;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private readonly int width;
        private readonly int height;
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void Draw()
        {
            DrawLine('*', '*');

            for (int i = 0; i < this.height - 2; i++)
            {
                DrawLine('*', ' ');
            }

            DrawLine('*', '*');
        }

        private void DrawLine(char borderSymbol, char fillerSymbol)
        {
            Console.Write(borderSymbol);

            for (int i = 0; i < this.width - 2; i++)
            {
                Console.Write(fillerSymbol);
            }

            Console.WriteLine(borderSymbol);
        }
    }
}
