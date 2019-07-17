using VehiclesExtension.Exceptions;

namespace VehiclesExtention.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private int tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;

            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption
        {
            get => this.fuelConsumption;
            protected set => this.fuelConsumption = value;
        }
        public int TankCapacity
        {
            get => this.tankCapacity;
            protected set => this.tankCapacity = value;
        }
        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                throw new LowFuelException($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {

            if (liters <= 0)
            {
                throw new NegativeFuelException();
            }

            else if (liters + this.FuelQuantity > this.TankCapacity)
            {
                throw new TankAvailableSpaceException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
