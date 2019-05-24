using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    public class Program
    {
        public static void Main()
        {
            HashSet<string> vips = new HashSet<string>();
            HashSet<string> guests = new HashSet<string>();
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            string entry = Console.ReadLine();

            while (entry != "PARTY")
            {
                if(char.IsDigit(entry[0]))
                {
                    vips.Add(entry);
                }
                else
                {
                    guests.Add(entry);
                }
                entry = Console.ReadLine();
            }

            entry = Console.ReadLine();

            while (entry != "END")
            {
                if (char.IsDigit(entry[0]))
                {
                    vips.Remove(entry);
                }
                else
                {
                    guests.Remove(entry);
                }

                entry = Console.ReadLine();
            }

            Console.WriteLine(vips.Count + guests.Count);

            foreach (var guest in vips)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }

        }
    }
}
