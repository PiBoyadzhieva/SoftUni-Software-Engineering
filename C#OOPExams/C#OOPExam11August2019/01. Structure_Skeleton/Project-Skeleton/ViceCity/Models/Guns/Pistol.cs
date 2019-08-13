using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBulets = 100;
        private const int shoots = 1;

        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBulets)
        {
        }

        public override int Fire()
        {
            this.BulletsPerBarrel -= 1;

            if(this.BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel = Math.Min(this.TotalBullets, InitialBulletsPerBarrel);
                this.TotalBullets -= this.BulletsPerBarrel;
            }

            return shoots;
        }
    }
}
