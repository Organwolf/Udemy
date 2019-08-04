using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Casting
{

    class Program
    {
        static void Main(string[] args)
        {
            // the text and shape object are pointing 
            // to the same object in memory

            // var text = new Text();
            Shape shape = new Text();
            Text text = (Text)shape;
        }
    }
}
