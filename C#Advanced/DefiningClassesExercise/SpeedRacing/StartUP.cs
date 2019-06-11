using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] input = Console.ReadLine().Split();

                string carModel = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKm = double.Parse(input[2]);

                Car car = new Car(carModel, fuelAmount, fuelConsumptionPerKm);
                cars.Add(car);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "End")
                {
                    break;
                }

                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = data[1];
                double distance = int.Parse(data[2]);

                Car car = cars.FirstOrDefault(c => c.Model == carModel);
                car.Drive(distance);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
