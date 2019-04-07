using System;
using System.Linq;
using System.Collections.Generic;

namespace Orders
{
    public class Program
    {
        public static void Main()
        {
            var productQuantity = new Dictionary<string, int>();
            var productPrice = new Dictionary<string, decimal>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                string[] tokens = input.Split();

                string product = tokens[0];
                decimal price = decimal.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (!productPrice.ContainsKey(product))
                {
                    productQuantity[product] = quantity;
                }
                else
                {
                    productQuantity[product] += quantity;
                }

                productPrice[product] = price;

            }

            foreach (var kvp in productQuantity)
            {
                string product = kvp.Key;
                int quantity = kvp.Value;
                decimal price = productPrice[product];
                decimal total = price * quantity;

                Console.WriteLine($"{product} -> {total}");
            }

        }
    }
}
