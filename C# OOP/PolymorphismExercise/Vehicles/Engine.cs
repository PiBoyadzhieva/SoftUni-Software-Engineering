using System;

namespace Vehicles
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split();

            Vehicle car = CreateCar(carInfo);

            string[] truckInfo = Console.ReadLine()
                .Split();

            Vehicle truck = CreateTruck(truckInfo);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split();

                string vehicleCommand = commands[0];
                string vehicleType = commands[1];

                if (vehicleCommand == "Drive")
                {
                    double distance = double.Parse(commands[2]);

                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }

                else if (vehicleCommand == "Refuel")
                {
                    double liters = double.Parse(commands[2]);

                    if (vehicleType == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }

        private static Vehicle CreateTruck(string[] truckInfo)
        {
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);

            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);
            return truck;
        }

        private static Vehicle CreateCar(string[] carInfo)
        {
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);

            Vehicle car = new Car(carFuelQuantity, carFuelConsumption);
            return car;
        }
    }
}
