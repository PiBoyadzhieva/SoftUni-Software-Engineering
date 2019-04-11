using System;
using System.Linq;
using System.Collections.Generic;

namespace VaporWinterSale
{
    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(", ");
            var gamePrice = new Dictionary<string, double>();
            var gameWithDlc = new Dictionary<string, string>();


            for (int i = 0; i < input.Length; i++)
            {
                string currentInput = input[i];

                if (currentInput.Contains("-"))
                {
                    string[] tokens = currentInput.Split("-");

                    string game = tokens[0];
                    double price = double.Parse(tokens[1]);

                    gamePrice.Add(game, price);

                }

                else if (currentInput.Contains(":"))
                {
                    string[] tokens = currentInput.Split(":");

                    string game = tokens[0];
                    string dlc = tokens[1];

                    if(gamePrice.ContainsKey(game))
                    {
                        gameWithDlc.Add(game, dlc);
                        gamePrice[game] *= 1.2;
                    }
                }
            }

            Dictionary<string, double> gamesReducedPrise = new Dictionary<string, double>();

            foreach (var item in gamePrice)
            {
                string game = item.Key;
                double priceDLC = item.Value;

                if (gameWithDlc.ContainsKey(game))
                {
                    gamesReducedPrise[game] = priceDLC * 0.5;
                }
                else
                {
                    gamesReducedPrise[game] = priceDLC * 0.8;
                }
            }

            foreach (var kvp in gamesReducedPrise.OrderBy(x => x.Value))
            {
                string game = kvp.Key;
                double price = kvp.Value;

                if(gameWithDlc.ContainsKey(game))
                {
                    Console.WriteLine($"{game} - {gameWithDlc[game]} - {price:f2}");
                }
            }

            foreach (var kvp in gamesReducedPrise.OrderByDescending(x => x.Value))
            {
                string game = kvp.Key;
                double price = kvp.Value;

                if (!gameWithDlc.ContainsKey(game))
                {
                    Console.WriteLine($"{game} - {price:f2}");
                }
            }
        }
    }
}
