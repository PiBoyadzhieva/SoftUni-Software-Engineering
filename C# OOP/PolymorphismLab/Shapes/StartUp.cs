using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            Circle circle = new Circle(2);

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
            Console.WriteLine();

            Rectangle rectangle = new Rectangle(2, 4);

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());
            Console.WriteLine();

            Shape circle2 = new Circle(2);

            Console.WriteLine(circle2.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
            Console.WriteLine();

            Shape rectangle2 = new Rectangle(2, 3);

            Console.WriteLine(rectangle2.CalculateArea());
            Console.WriteLine(rectangle2.CalculatePerimeter());
            Console.WriteLine(rectangle2.Draw());
            Console.WriteLine();
        }
    }
}
