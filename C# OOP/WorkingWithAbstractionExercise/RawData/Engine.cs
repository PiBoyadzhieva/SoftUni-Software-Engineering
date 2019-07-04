using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RawData
{
    public class Engine
    {
        private List<Car> cars;

        public Engine()
        {
            this.cars = new List<Car>();
        }
        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    ?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = CreateCar(parameters);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                PrintInfo(fragile);
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.CargoType == "flamable" && x.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                PrintInfo(flamable);
            }
        }

        private void PrintInfo(List<string> cars)
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
        private static Car CreateCar(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            double firstTirePressure = double.Parse(parameters[5]);
            int firstTireAge = int.Parse(parameters[6]);
            Tire firstTire = new Tire(firstTireAge, firstTirePressure);

            double secondTirePressure = double.Parse(parameters[7]);
            int secondTireAge = int.Parse(parameters[8]);
            Tire secondTire = new Tire(firstTireAge, firstTirePressure);

            double thirdTirePressure = double.Parse(parameters[9]);
            int thirdTireAge = int.Parse(parameters[10]);
            Tire thirdTire = new Tire(firstTireAge, firstTirePressure);

            double fourthTirePressure = double.Parse(parameters[11]);
            int fourthTireAge = int.Parse(parameters[12]);
            Tire fourthTire = new Tire(firstTireAge, firstTirePressure);

            //Tire[] tires = new Tire[] { firstTire, secondTire, thirdTire, fourthTire };
            Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType,
                firstTire, secondTire, thirdTire, fourthTire);

            return car;
        }
    }
}
