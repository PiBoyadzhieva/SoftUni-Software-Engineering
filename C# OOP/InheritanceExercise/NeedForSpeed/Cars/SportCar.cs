﻿namespace NeedForSpeed.Cars
{
    public class SportCar : Car
    {
        private const double DefaultFuelConsumption = 10;

        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}