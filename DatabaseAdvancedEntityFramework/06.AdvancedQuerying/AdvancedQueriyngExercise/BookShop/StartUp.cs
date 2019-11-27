namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                //string input = Console.ReadLine();
                string result = GetMostRecentBooks(db);

                Console.WriteLine(result);
            }
        }

        //Problem 1
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();

            //second Way:
            //var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            //var books = context.Books
            //    .Where(b => b.AgeRestriction == ageRestriction)
            //    .Select(b => new
            //    {
            //        b.Title
            //    })
            //    .OrderBy(b => b.Title)
            //    .ToList();

            //var result = string.Join(Environment.NewLine, books);
            //return result;

        }

        //Problem 2
        public static string GetGoldenBooks(BookShopContext context)

        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType.ToString() == "Gold")
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();


            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 3
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 4
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 5
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToList();

            var books = context.BooksCategories
                .Where(bc => categories
                    .Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(b => b)
                .ToList();
                

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 6
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < dateTime)
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => new 
                { 
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            //string result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}"));

            return sb.ToString().TrimEnd();
        }

        //Problem 7
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 8
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Title.ToLower()
                    .Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 9
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            //var books = context.Books
            //    .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            //    .OrderBy(b => b.BookId)
            //    .Select(b => new
            //    {
            //        b.Title,
            //        AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
            //    })
            //    .ToList();

            var books = context.Books
                .Where(a => EF.Functions.Like(a.Author.LastName, $"{input}%"))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        //Problem 11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    bookCopiesSum = a.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(a => a.bookCopiesSum)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.AuthorName} - {author.bookCopiesSum}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var totalPofit = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks
                        .Select(cb => cb.Book)
                        .Sum(b => b.Price * b.Copies)
                })
                .OrderByDescending(b => b.Profit)
                .ThenBy(b => b.Name)
                .ToList();

            foreach (var category in totalPofit)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var mostRecentBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Take(3)
                        .Select(b => new
                        {
                            b.Book.Title,
                            ReleaseYear = b.Book.ReleaseDate.Value.Year
                        })
                        .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in mostRecentBooks)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();

            //with Z.EFPlus
            //var books = context.Books
            //    .Where(b => b.ReleaseDate.Value.Year < 2010)
            //    .Update(x => new Book() { Price = x.Price + 5 });
        }

        //Problem 15
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            int affectedRows = context.SaveChanges();

            return affectedRows;

            //with Z.EFPlus
            //return context.Books
            //    .Where(b => b.Copies < 4200)
            //    .Delete();
        }
    }
}
