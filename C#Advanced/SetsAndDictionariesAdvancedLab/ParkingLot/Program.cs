using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class Program
    {
        public static void Main()
        {
            string[] entry = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> carPlates = new HashSet<string>();

            while (entry[0]?.ToLower() != "end")
            {
                if(entry[0] == "IN")
                {
                    carPlates.Add(entry[1]);
                }

                if(entry[0] == "OUT")
                {
                    carPlates.Remove(entry[1]);
                }

                entry = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if(carPlates.Count > 0)
            {
                foreach (var plate in carPlates)
                {
                    Console.WriteLine(plate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
