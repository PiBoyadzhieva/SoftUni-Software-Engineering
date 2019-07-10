using System;
using PizzaCalories.Models;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaItems = Console.ReadLine()
                    .Split();

                string pizzaName = pizzaItems[1];

                string[] doughItems = Console.ReadLine()
                    .Split();

                string flourType = doughItems[1];
                string bakingTechnique = doughItems[2];
                double weight = double.Parse(doughItems[3]);

                Dough dough = new Dough(flourType, bakingTechnique, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string lines = Console.ReadLine();

                while (lines != "END")
                {
                    string[] toppingItems = lines
                        .Split();

                    string toppingType = toppingItems[1];
                    double toppingWeigh = double.Parse(toppingItems[2]);

                    Topping topping = new Topping(toppingType, toppingWeigh);

                    pizza.AddTopping(topping);

                    lines = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }

            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
