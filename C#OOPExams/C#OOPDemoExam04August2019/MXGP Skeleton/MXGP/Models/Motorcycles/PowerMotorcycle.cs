using System;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double PowerMotorcycleCubicCentimeters = 450;
        private const int minHorsePower = 70;
        private const int maxHorsePower = 100;

        private int horsePower;

        public PowerMotorcycle
            (string model, int horsePower)
            : base(model, horsePower, PowerMotorcycleCubicCentimeters)

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
                if(value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                horsePower = value;
            }
        }
    }
}
