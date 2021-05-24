using System;

namespace ArgumentsProcessor
{
    class Program
    {
        static void Main(string[] args)
        {

            bool b = Argument.TryParse<uint>(args[0], 0, 10, out uint a);
            Console.WriteLine(a + " " + b);
            
            b = Argument.TryParse<double>(args[0], 2, 10, out double d);
            Console.WriteLine(d + " " + b);
        }
    }
}
