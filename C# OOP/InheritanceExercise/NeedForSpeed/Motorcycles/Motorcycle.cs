namespace NeedForSpeed.Motorcycles
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int horsePower, double fuel)
            :base(horsePower, fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
    }
}
