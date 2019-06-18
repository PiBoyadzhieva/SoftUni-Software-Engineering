using System;

namespace IteratorsAndComparators
{
    public class Program
    {
        public static void Main()
        {
            var library = new Library();

            library.Add(new Book("Amazon", 2016, "Pesho"));
            library.Add(new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace"));
            library.Add(new Book("The Documents in the Case", 1930));


            foreach (var book in library)
            {
                Console.WriteLine(book.Title);
            }

        }
    }
}
