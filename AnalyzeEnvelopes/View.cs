﻿using System;

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
    }
}