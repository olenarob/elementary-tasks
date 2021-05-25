using ArgumentsProcessor;
using System;

namespace AnalyzeEnvelopes
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

                Console.Write("Go again? Y/N: ");
                userAnswer = Console.ReadLine();
            }
            while (IsRepeat(userAnswer));
        }

        private static bool IsRepeat(string userAnswer)
        {
            return userAnswer.Equals("y", StringComparison.CurrentCultureIgnoreCase)
                || userAnswer.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
        }

        private static Envelope GetEnvelopeFromUserInput(int envelopeIndex)
        {
            return new Envelope(
                Argument.GetValueFromUser($"first side of envelope {envelopeIndex}", double.Epsilon, double.MaxValue),
                Argument.GetValueFromUser($"second side of envelope {envelopeIndex}", double.Epsilon, double.MaxValue));
        }
    }
}
