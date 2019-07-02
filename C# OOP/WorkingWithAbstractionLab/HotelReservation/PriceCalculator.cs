using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public class PriceCalculator
    {
        public decimal PricePerDay { get; private set; }
        public int NumberOfDays { get; private set; }
        public Season Season { get; private set; }
        public Discount Discount { get; set; }

        public decimal CalculatePrice(decimal pricePerDay, int numberOfDays, Season season, Discount discount)
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discount / 100;

            decimal PriceBeforeDiscount = numberOfDays * pricePerDay * multiplier;
            decimal discountedAmount = PriceBeforeDiscount * discountMultiplier;
            decimal finalPrice = PriceBeforeDiscount - discountedAmount;

            return finalPrice;
        }
    }
}
