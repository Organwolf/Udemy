using System;
using System.Collections.Generic;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lambda Expressions
            const int factor = 6;
            Func<int, int> multiplier = n => n * factor;
            var result = multiplier(2);
            Console.WriteLine(result);
        }
    }
}

