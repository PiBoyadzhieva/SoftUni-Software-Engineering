using System;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double SpeedMotorcycleCubicCentimeters = 125;
        private const int minHorsePower = 50;
        private const int maxHorsePower = 69;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, SpeedMotorcycleCubicCentimeters)

        {

        }

        public override int HorsePower
        {
            get
            {
                return horsePower;
            }

            protected set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                horsePower = value;
            }
        }
    }
}
