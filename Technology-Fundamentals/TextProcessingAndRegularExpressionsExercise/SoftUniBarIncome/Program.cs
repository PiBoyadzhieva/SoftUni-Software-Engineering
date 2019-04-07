using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    public class Program
    {

        public static void Main()
        {
            string pattern = @"\%(?<customer>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+([.]\d+)?)\$";
            string input = string.Empty;
            double totalIncome = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Regex order = new Regex(pattern);

                if(order.IsMatch(input))
                {
                    string customerName = order.Match(input).Groups["customer"].Value;
                    string productName = order.Match(input).Groups["product"].Value;
                    int count = int.Parse(order.Match(input).Groups["count"].Value);
                    double prices = double.Parse(order.Match(input).Groups["price"].Value);

                    double totalPrice = count * prices;
                    totalIncome += totalPrice;

                    Console.WriteLine($"{customerName}: {productName} - {totalPrice:f2}");
                }
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
