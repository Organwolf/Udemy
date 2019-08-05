var books = new BookRepository().GetBooks();

// Linq Query Operators
var cheaperBooks =
    from b in books
    where b.Price < 10
    orderby b.Title
    select b.Title;

// Linq Extension methods
var cheapBooks = books
                    .Where(b => b.Price < 10)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title);

foreach(var book in cheapBooks)
{
    Console.WriteLine(book); // Using Select(b => b.Title) returns a IEnumberable<string> 
    //Console.WriteLine(book.Title + " " + book.Price);
}