using System;

namespace AnalysisOfEnvelopes
{
    public class View
    {
        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }

        public string GetUserMessage(string text)
        {
            Console.WriteLine();
            Console.Write(text);
            return Console.ReadLine();
        }

        public void DisplayHelp()
        {
            Console.WriteLine();
            Console.WriteLine("============================= Help ===========================");
            Console.WriteLine("Usage: AnalysisOfEnvelopes.exe");
            Console.WriteLine();
        }

        public void DisplayTask()
        {
            Console.WriteLine();
            Console.WriteLine($"=================== Task 2 Analysis of envelopes =================");
            Console.WriteLine("You need to convert an entire number into a text: 12 - twelve.");
            Console.WriteLine("The program runs through a main class call with arguments.");
            Console.WriteLine($"=============================================================");
            Console.WriteLine();
        }
    }
}
