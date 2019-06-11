using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Tire[] tires = new Tire[]
                {
                    new Tire(double.Parse(input[5]),int.Parse(input[6])),
                    new Tire(double.Parse(input[7]),int.Parse(input[8])),
                    new Tire(double.Parse(input[9]),int.Parse(input[10])),
                    new Tire(double.Parse(input[11]),int.Parse(input[12])),
                };

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(n => n.Cargo.Type == "fragile"))
                {
                    if (car.Tires.Where(n => n.Pressure < 1).Count() > 0)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in cars.Where(n => n.Cargo.Type == "flamable").Where(n => n.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
