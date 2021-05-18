using System;

namespace LuckyTickets
{
    public delegate bool IsLuckyTicket(Ticket t);
    
    class Program
    {
        static void Main(string[] args)
        {
            var start = GC.GetTotalAllocatedBytes(true);

            int countSimple = 0;
            int countComplex = 0;

            int min = Convert.ToInt32(args[0]);
            int max = Convert.ToInt32(args[1]);

            var ticket = new Ticket();
            for (int j = min; j <= max; j++)
            {
                ticket.TicketNumber = Ticket.Format(j);
                if (Ticket.IsLuckySimple(ticket))
                    countSimple++;
                if (Ticket.IsLuckyComplex(ticket))
                    countComplex++;
            }

            Console.WriteLine(countSimple);
            Console.WriteLine(countComplex);

            var end = GC.GetTotalAllocatedBytes(true);
            Console.WriteLine("Allocated bytes: " + (end - start).ToString());
        }
   }
    public class Ticket
    {
        static string _format = new string('0', 6);
        public string ticketNumber;

        public string TicketNumber
        {
            get { return ticketNumber; }
            set
            {
                //Char.IsDigit(ticketNumber[0]);
                ticketNumber = value;
            }
        }

       // static int zeroCode = '0';

        static int CharToInt(char c)
        {
            return c - '0';
        }
        
        public static bool IsLuckySimple(Ticket ticket)
        {
            int sum1 = 0;
            for (int i=0; i < 3; i++)
            {
                sum1 += CharToInt(ticket.TicketNumber[i]);
            }
            
            int sum2 = 0;
            for (int i = 3; i < 6; i++)
            {
                sum2 += CharToInt(ticket.TicketNumber[i]);
            }

            return sum1 == sum2;
        }

        public static bool IsLuckyComplex(Ticket ticket)
        {
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < 6; i++)
            {
                if (i % 2 == 0)
                    sum1 += CharToInt(ticket.TicketNumber[i]);
                else
                    sum2 += CharToInt(ticket.TicketNumber[i]);
            }
            return sum1 == sum2;
        }
        
        public static string Format(int value)
        {
            return value.ToString(_format);
        }
    }
}
