using System.Collections.Generic;

namespace Linq
{
    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() { Title = "ADO.Net", Price = 10 },
                new Book() { Title = "ASP.Net MVC", Price = 5 },
                new Book() { Title = "ASP.Net MVC", Price = 7 },
                new Book() { Title = "XYZ", Price = 2.99f },
            };
        }
    }
}
