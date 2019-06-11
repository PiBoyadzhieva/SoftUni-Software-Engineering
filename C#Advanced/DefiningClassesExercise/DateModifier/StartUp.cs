using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier(firstDate, secondDate);

            Console.WriteLine(dateModifier.Difference());
        }
    }
}
