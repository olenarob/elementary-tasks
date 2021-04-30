using ArgumentsProcessor;
using System;

namespace NumberToString
{
    class Program
    {
        static void Main(string[] args)
        {
            int value;
            
            if ((args.Length > 0) &&
                Argument.TryParseInt(args[0], 1, int.MaxValue, out value))
            {
                Console.Write(value + " - "+ new Numbers(value));
            }
            else
            {
                Console.WriteLine("Usage: NumberToString.exe [number]");
            }
        }
    }
}
