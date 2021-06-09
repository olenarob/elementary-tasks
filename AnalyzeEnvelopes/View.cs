using System;

namespace AnalysisOfEnvelopes
{
    public class View
    {
        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }

        public string GetUserInput(string text)
        {
            Console.WriteLine();
            Console.Write(text);
            return Console.ReadLine();
        }

        public void DisplayTask()
        {
            Console.WriteLine();
            Console.WriteLine("====================== Task 2 Analysis of envelopes ========================");
            Console.WriteLine();
            Console.WriteLine("There are two envelopes with sides (a,b) and (c,d),");
            Console.WriteLine("to determine whether one envelope can be put in the other.");
            Console.WriteLine();
            Console.WriteLine("The program must process floating-point input.");
            Console.WriteLine("The program asks the user for the size of envelopes at one option at a time.");
            Console.WriteLine("After each counting, the program asks the user if he wants to continue.");
            Console.WriteLine(@"If the user replies ""y"" or ""yes"" (without registering),");
            Console.WriteLine("the program continues to work first, otherwise it completes the execution.");
            Console.WriteLine("============================================================================");
            Console.WriteLine();
        }
    }
}
