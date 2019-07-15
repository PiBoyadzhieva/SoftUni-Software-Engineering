using FoodShortage.Contracts;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage.Core
{
    public class Engine
    {
        private List<IBuyer> buyers;
        public Engine()
        {
            buyers = new List<IBuyer>();
        }
        public void Run()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] lines = Console.ReadLine()
                    .Split();

                string name = lines[0];
                int age = int.Parse(lines[1]);

                if(lines.Length == 4)
                {
                    string id = lines[2];
                    string birthdare = lines[3];

                    Citizen citizen = new Citizen(name, age, id, birthdare);
                    buyers.Add(citizen);
                }
                else if(lines.Length == 3)
                {
                    string group = lines[2];

                    Rebel rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }

            string namesOfPeople = Console.ReadLine();

            while(namesOfPeople != "End")
            {
                IBuyer buyer = this.buyers.FirstOrDefault(p => p.Name == namesOfPeople);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                namesOfPeople = Console.ReadLine();
            }

            int totalSum = this.buyers.Sum(x => x.Food);

            Console.WriteLine(totalSum);
        }
    }
}
