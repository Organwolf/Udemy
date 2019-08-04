using System;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.SetBirthDate(new DateTime(1987, 08, 04));
            Console.WriteLine(person.GetBirthdate());
        }
    }
}
