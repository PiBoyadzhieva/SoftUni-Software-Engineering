using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            Car myCar = new Car();

            myCar.Make = "BMW";
            myCar.Model = "M5 Competition";
            myCar.Year = 2018;
            myCar.FuelQuantity = 54;
            myCar.FuelConsumption = 12;

            Console.WriteLine(myCar.WhoAmI());

            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsuption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsuption);

            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)
            };

            var engine = new Engine(560, 6300);

            var equippedCar = new Car("BMW", "M5 Competition", 2019, 90, 18, engine, tires);
        }
    }
}
