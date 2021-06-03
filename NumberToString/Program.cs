using System;
using System.Numerics;

namespace NumberToString
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var number = BigInteger.Parse(args[0]);
                Console.Write($"{number:N0} - {new NumberToString(number)}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Usage: NumberToString [number]");
            }
            catch (FormatException)
            {
                Console.WriteLine("The input string is not a sequence of digit!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
