using System;

namespace AnalysisOfEnvelopes
{
    public class View
    {
        public void DisplayHelp()
        {
            Console.WriteLine("Usage: AnalysisOfEnvelopes.exe [-help]");
        }
        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }

        public string GetUserValue(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }
    }
}
