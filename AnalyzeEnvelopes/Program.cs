﻿using ArgumentsProcessor;
using System;

namespace AnalysisOfEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            string userAnswer;
            do
            {
                Envelope envelope1 = GetEnvelopeFromUserInput(1);
                Envelope envelope2 = GetEnvelopeFromUserInput(2);
                Console.WriteLine(envelope1.CheckInsertion(envelope2));

                Console.Write("Try again? ");
                userAnswer = Console.ReadLine();
            }
            while (IfRepeat(userAnswer));
        }

        private static bool IfRepeat(string userAnswer)
        {
            return userAnswer.Equals("y", StringComparison.CurrentCultureIgnoreCase)
                || userAnswer.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
        }

        private static Envelope GetEnvelopeFromUserInput(int envelopeIndex)
        {
            double side1 = Argument.GetValueFromUser($" first side of envelope {envelopeIndex}", double.Epsilon, double.MaxValue);
            double side2 = Argument.GetValueFromUser($"second side of envelope {envelopeIndex}", double.Epsilon, double.MaxValue);
            
            return new Envelope(side1, side2);
        }
    }
}
