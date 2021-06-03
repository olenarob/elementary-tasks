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
                var number1 = new NumberToString(number);
                Console.WriteLine($"{number:N0} - {number1}");
                Console.Write(number1.Number);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Usage: NumberToString.exe <integer positive number>");
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
