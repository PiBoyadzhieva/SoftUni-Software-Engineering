namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double airCondition = 1.6;
        private const double lostFuel = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += airCondition;
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * lostFuel);
        }
    }
}
