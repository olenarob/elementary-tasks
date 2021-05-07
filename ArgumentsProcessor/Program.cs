using System;

namespace ArgumentsProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            double d = 0;
            bool b = Argument.TryParse<int>(args[0], 2, 10, out a);
            Console.WriteLine(a + " " + b);
            b = Argument.TryParse<double>(args[0], 2, 10, out d);
            Console.WriteLine(d + " " + b);
        }
    }
}
