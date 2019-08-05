using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace SoftUniRestaurant.Models.Drinks.Factories
{
    public class DrinkFactory
    {
        public IDrink CreateDrink(string drinkType, string name, int servingSize, string brand)
        {
            //return (IDrink)Assembly.GetCallingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(x => x.Name == drinkType)
            //    .GetConstructors()
            //    .FirstOrDefault()
            //    .Invoke(new object[] { name, servingSize, brand });

            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == drinkType);

            IDrink drink = (IDrink)Activator.CreateInstance(type, name, servingSize, brand);

            return drink;
        }
    }
}
