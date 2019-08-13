using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBulets = 500;
        private const int Shoots = 5;

        public Rifle(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBulets)
        {
        }

        public override int Fire()
        {
            this.BulletsPerBarrel -= Shoots;

            if (this.BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel = Math.Min(this.TotalBullets, InitialBulletsPerBarrel);
                this.TotalBullets -= this.BulletsPerBarrel;
            }

            return Shoots;
        }
    }
}
