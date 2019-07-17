using VehiclesExtention.Models;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double airCondition = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airCondition;
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= airCondition;

            return base.Drive(distance);
        }
    }
}
