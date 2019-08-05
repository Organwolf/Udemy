using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            // LINQ Extension Methods
            // books.Where();
            //var book = books.SingleOrDefault(b => b.Title == "XYZ!");
            //var book = books.First(b => b.Title == "ASP.Net MVC");
            //var PagedBooks = books.Skip(1).Take(2);
            //var count = books.Count();
            //var count = books.Max(b => b.Price);
            var count = books.Sum(b => b.Price);

            Console.WriteLine(count);
            //foreach (var book in PagedBooks)
            //{
            //    Console.WriteLine(book.Title);
            //}
        }
    }
}
