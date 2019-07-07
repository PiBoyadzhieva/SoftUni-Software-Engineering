﻿namespace NeedForSpeed.Cars
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3;

        public Car(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
