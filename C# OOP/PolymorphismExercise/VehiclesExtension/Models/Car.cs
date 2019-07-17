namespace VehiclesExtention.Models
{
    public class Car : Vehicle
    {
        private const double airCondition = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airCondition;
        }
    }
}
