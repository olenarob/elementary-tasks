using ArgumentsProcessor;
using System;

namespace NumberToString
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //if (Argument.TryParse<int>(args[0], 1, int.MaxValue, out int number))
                int number = int.Parse(args[0]);
                    Console.Write($"{number} - {new NumberToString(number)}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Usage: NumberToString [number]");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
