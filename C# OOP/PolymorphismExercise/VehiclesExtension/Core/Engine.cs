using System;
using VehiclesExtension.Exceptions;
using VehiclesExtension.Models;
using VehiclesExtention.Models;

namespace VehiclesExstention.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split();
            string[] truckInfo = Console.ReadLine()
                .Split();
            string[] busInfo = Console.ReadLine()
                .Split();

            Vehicle car = CreateCar(carInfo);
            Vehicle truck = CreateTruck(truckInfo);
            Bus bus = CreateBus(busInfo);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                try
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
                        else if (vehicleType == "Bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
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
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(liters);
                        }
                    }

                    else if (vehicleCommand == "DriveEmpty")
                    {
                        double distance = double.Parse(commands[2]);

                        Console.WriteLine(bus.DriveEmpty(distance));
                    }

                }
                catch (LowFuelException lfe)
                {
                    Console.WriteLine(lfe.Message);
                }
                catch(NegativeFuelException nfe)
                {
                    Console.WriteLine(nfe.Message);
                }
                catch(TankAvailableSpaceException tase)
                {
                    Console.WriteLine(tase.Message);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }

        private static Bus CreateBus(string[] busInfo)
        {
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            int busTankCapacity = int.Parse(busInfo[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);
            return bus;
        }

        private static Vehicle CreateTruck(string[] truckInfo)
        {
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            int truckTankCapacity = int.Parse(truckInfo[3]);

            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
            return truck;
        }

        private static Vehicle CreateCar(string[] carInfo)
        {
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            int carTankCapacity = int.Parse(carInfo[3]);

            Vehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
            return car;
        }
    }
}
