using System;
using System.Collections.Generic;

namespace Crossroads
{
    public class Program
    {
        public static void Main()
        {
            Queue<string> queueOfCars = new Queue<string>();

            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            bool isHitted = false;
            String hittedCarName = string.Empty;
            char hittedSymbol = '\0';
            int totalCars = 0;
                
            while (input != "END")
            {
                if(input != "green")
                {
                    queueOfCars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                int currentGreenLightDuration = greenLightDuration;

                while (currentGreenLightDuration > 0 && queueOfCars.Count > 0)
                {
                    string carName = queueOfCars.Dequeue();
                    int carLength = carName.Length;

                    if(currentGreenLightDuration - carLength >=0)
                    {
                        currentGreenLightDuration -= carLength;
                        totalCars++;
                    }
                    else
                    {
                        currentGreenLightDuration += freeWindowDuration;

                        if (currentGreenLightDuration - carLength >= 0)
                        {
                            totalCars++;
                            break;
                        }
                        else
                        {
                            isHitted = true;
                            hittedCarName = carName;
                            hittedSymbol = carName[currentGreenLightDuration];
                            break;
                        }
                    }
                }

                if(isHitted)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if(isHitted)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hittedCarName} was hit at {hittedSymbol}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCars} total cars passed the crossroads.");
            }
        }
    }
}
