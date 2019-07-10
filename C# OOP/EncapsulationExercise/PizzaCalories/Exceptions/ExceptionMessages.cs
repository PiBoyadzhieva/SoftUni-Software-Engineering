namespace PizzaCalories.Exceptions
{
    public static class ExceptionMessages
    {
        public static string InvalidTypeOfDough = "Invalid type of dough.";
        public static string InvalidWeghtOfDough = "Dough weight should be in the range [1..200].";

        public static string InvalidToppingType = "Cannot place {0} on top of your pizza.";
        public static string InvalidToppingWeight = "{0} weight should be in the range [1..50].";
        public static string InvalidTopingCount = "Number of toppings should be in range [0..10].";

        public static string InvalidPizzaName = "Pizza name should be between 1 and 15 symbols.";
    }
}
