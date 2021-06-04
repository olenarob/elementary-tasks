using System;

namespace LuckyTickets
{
    class View
    {
        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }

        public void DisplayHelp()
        {
            Console.WriteLine();
            Console.WriteLine("============================= Help ===========================");
            Console.WriteLine("Usage: LuckyTickets.exe <lower range> <upper range>");
            Console.WriteLine(@$"The lower range and upper range format: ""000000"".");
            Console.WriteLine();
        }

        public void DisplayTask()
        {
            Console.WriteLine();
            Console.WriteLine($"=================== Task 6 Lucky tickets ====================");
            Console.WriteLine("There are two ways to count lucky tickets: simple and complex.");
            Console.WriteLine("Determine the programmatics, which option is to count lucky");
            Console.WriteLine(" tickets for each method of counting.");
            Console.WriteLine($"=============================================================");
            Console.WriteLine();
        }
    }
}
