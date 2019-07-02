using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation
{
    public class Program
    {
        public static void Main()
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            Season season = (Season)Enum.Parse(typeof(Season), input[2]);
            Discount discount = Discount.None;

            if(input.Count == 4)
            {
                discount = (Discount)Enum.Parse(typeof(Discount), input[3]);
            }

            PriceCalculator priceCalculator = new PriceCalculator();
            decimal totalPrice = priceCalculator.CalculatePrice(pricePerDay, numberOfDays, season, discount);

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
