using System;

namespace FileParser
{
    public class View : IView
    {
        public void DisplayHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("1. <path> <string to count>");
            Console.WriteLine("2. <path> <string to search> <string to replace>");
        }
        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }
    }
}
