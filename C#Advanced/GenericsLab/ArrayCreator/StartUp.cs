using System;

namespace GenericArrayCreator
{
    class StartUp
    {
        public static void Main()
        {
            //string[] strings = ArrayCreator<string>.Create(5, "Pesho");

            string[] strings = ArrayCreator.Create(5, "Pesho");

            int[] integers = ArrayCreator.Create(10, 33);
        }
    }
}
