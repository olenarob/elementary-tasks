using System;
using System.Numerics;

namespace NumberToString
{
    public class View
    {
        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }

        public void DisplayBigNumber(BigInteger number)
        {
            Console.WriteLine($"{number:N0}");
        }

        public void DisplayHelp()
        {
            Console.WriteLine();
            Console.WriteLine("============================= Help ===========================");
            Console.WriteLine("Usage: NumberToString.exe <integer positive number>");
            Console.WriteLine($"The number is an integer more than zero.");
            Console.WriteLine();
        }

        public void DisplayTask()
        {
            Console.WriteLine();
            Console.WriteLine($"=================== Task 5 Number to string =================");
            Console.WriteLine("You need to convert an entire number into a text: 12 - twelve.");
            Console.WriteLine("The program runs through a main class call with arguments.");
            Console.WriteLine($"=============================================================");
            Console.WriteLine();
        }
    }
}
