namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Drinks.Factories;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Foods.Factories;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using SoftUniRestaurant.Models.Tables.Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private readonly IList<IFood> menu;
        private readonly IList<IDrink> drinks;
        private readonly IList<ITable> tables;
        private readonly FoodFactory foodFactory;
        private readonly DrinkFactory drinkFactory;
        private readonly TableFactory tableFactory;
        private decimal income;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
            this.income = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = this.foodFactory.CreateFood(type, name, price);

            this.menu.Add(food);

            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = drinkFactory.CreateDrink(type, name, servingSize, brand);

            this.drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = tableFactory.CreateTable(type, tableNumber, capacity);

            this.tables.Add(table);

            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            int tableNumber = table.TableNumber;
            table.Reserve(numberOfPeople);

            return $"Table {tableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if(table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IFood food = menu.FirstOrDefault(f => f.Name == foodName);

            if(food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";

        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal bill = table.GetBill();
            table.Clear();

            this.income += bill;

            var result = $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill:f2}";

            return result;
        }

        public string GetFreeTablesInfo()
        {
            var result = new StringBuilder();

            foreach (var table in tables.Where(t => !t.IsReserved))
            {
                result.AppendLine(table.GetFreeTableInfo());
            }

            return result.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var result = new StringBuilder();

            foreach (var table in tables.Where(t => t.IsReserved))
            {
                result.AppendLine(table.GetOccupiedTableInfo());
            }

            return result.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {income:f2}lv";
        }
    }
}
