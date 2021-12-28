using System;

namespace LuckyTickets
{
    public delegate bool Condition(int digit);

    public class Ticket
    {
        private string ticketNumber;
        private readonly string format;
        private readonly int numberOfDigits;

        public Ticket(int numberOfDigits)
        {
            this.format = new string('0', numberOfDigits);
            this.numberOfDigits = numberOfDigits;
        }

        public string TicketNumber
        {
            get { return ticketNumber; }
            set
            {
                for (int i = 0; i < NumberOfDigits; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new FormatException("Input string is not a sequence of 6 digits!");
                    }
                }
                ticketNumber = value;
            }
        }

        public int NumberOfDigits => numberOfDigits;

        public void SetNumber(int value)
        {
            TicketNumber = value.ToString(format);
        }

        static int CharToInt(char digit)
        {
            return digit - '0';
        }
        
        public static bool IsLucky(Ticket ticket, Condition condition)
        {
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < ticket.NumberOfDigits; i++)
            {
                if (condition(i))
                    sum1 += CharToInt(ticket.TicketNumber[i]);
                else
                    sum2 += CharToInt(ticket.TicketNumber[i]);
            }
            return sum1 == sum2;
        }
    }
}
