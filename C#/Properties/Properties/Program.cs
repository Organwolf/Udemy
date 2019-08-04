using System;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person(new DateTime(1987, 08, 04));
            Console.WriteLine(person.Age);
        }
    }
}
