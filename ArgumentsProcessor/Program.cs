using System;

namespace ArgumentsProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            uint a = 0;
            double d = 0;
            
            bool b = Argument.TryParse<uint>(args[0], 0, 10, out a);
            Console.WriteLine(a + " " + b);
            
            b = Argument.TryParse<double>(args[0], 2, 10, out d);
            Console.WriteLine(d + " " + b);
        }
    }
}
