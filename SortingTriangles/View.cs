using System;

namespace SortingTriangles
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
        public string[] GetArrayOfUserMessage(string text)
        {
            Console.WriteLine(text);
            var userInput = Console.ReadLine();
            var flags = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
            var args = userInput.Split(new char[] { ',', ' ' }, flags);
            return args;
        }
    }
}
