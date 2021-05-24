namespace LuckyTickets
{
    public class Ticket
    {
        public string ticketNumber;
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
            //set
            //{
            //    for (int i = 0; i < 6; i++)
            //    {
            //        if (!char.IsDigit(value[i]))
            //        {
            //            throw new FormatException("Input string is not a sequence of digits.");
            //        }
            //    }
            //    ticketNumber = value;
            //}
        }

        public void SetNumber(int value)
        {
            ticketNumber = value.ToString(format);
        }

        static int CharToInt(char digit)
        {
            return digit - '0';
        }
        
        public static bool IsLuckySimple(Ticket ticket)
        {
            int sum1 = 0;
            int sum2 = 0;
            int half = ticket.numberOfDigits / 2;
            for (int i = 0; i < ticket.numberOfDigits; i++)
            {
                if (i < half)
                    sum1 += CharToInt(ticket.TicketNumber[i]);
                else
                    sum2 += CharToInt(ticket.TicketNumber[i]);
            }
            return sum1 == sum2;
        }

        public static bool IsLuckyComplex(Ticket ticket)
        {
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < ticket.numberOfDigits; i++)
            {
                if (i % 2 == 0)
                    sum1 += CharToInt(ticket.TicketNumber[i]);
                else
                    sum2 += CharToInt(ticket.TicketNumber[i]);
            }
            return sum1 == sum2;
        }
    }
}
