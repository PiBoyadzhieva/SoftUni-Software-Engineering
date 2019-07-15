namespace Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driverName)
        {
            this.Model = "488-Spider";
            this.DriverName = driverName;
        }

        public string Model { get; private set; }

        public string DriverName { get; private set; }

        public string Brakes()
        {
            return "Gas!";
        }

        public string Gas()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Gas()}/{this.Brakes()}/{this.DriverName}";
        }
    }
}
