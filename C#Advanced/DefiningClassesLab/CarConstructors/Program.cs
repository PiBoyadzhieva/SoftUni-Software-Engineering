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

            //Console.WriteLine(car.WhoAmI());

        }
    }
}
