using VehiclesExtension.Exceptions;

namespace VehiclesExtention.Models
{
    public class Truck : Vehicle
    {
        private const double airCondition = 1.6;
        private const double lostFuel = 0.05;
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airCondition;
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);

            this.FuelQuantity -= liters * lostFuel;
        }
    }
}
