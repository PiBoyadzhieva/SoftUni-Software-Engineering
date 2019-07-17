namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double airCondition = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += airCondition;
        }
    }
}
