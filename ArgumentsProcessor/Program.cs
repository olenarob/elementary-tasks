using System;

namespace ArgumentsProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Argument
    {
        
        public static bool TryParseInt(string s, int min, int max, out int value)
        {
            bool success = true;
            try
            {
                    value = int.Parse(s);

                    if ((value < min) || (value > max))
                        throw new ArgumentOutOfRangeException();
            }
            catch
            {
                success = false;
                value = 0;
            }
            return success;
        }

    }
}
