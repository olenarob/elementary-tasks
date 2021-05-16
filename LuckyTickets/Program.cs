using System;

namespace LuckyTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = GC.GetTotalAllocatedBytes(true);
            Ticket.IsSimple(args[0],args[1]);
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
            get
            {
                return ticketNumber;
            }
            set
            {
                //Char.IsDigit(ticketNumber[0]);
                ticketNumber = value;
            }
        }

        static uint zeroCode = Convert.ToUInt32('0');

        static uint CharToInt(char ch)
        {
            return Convert.ToUInt32(ch) - zeroCode;
        }
        
        public bool LuckyTicketSimple()
        {
            uint sum1 = 0;
            for (int i=0; i < 3; i++)
            {
                sum1 += CharToInt(TicketNumber[i]);
            }
            
            uint sum2 = 0;
            for (int i = 3; i < 6; i++)
            {
                sum2 += CharToInt(TicketNumber[i]);
            }

            return sum1 == sum2;
        }

        public bool LuckyTicketComplex()
        {
            uint sum1 = 0;
            uint sum2 = 0;
            for (int i = 0; i < 6; i++)
            {
                if (i % 2 == 0)
                    sum1 += CharToInt(TicketNumber[i]);
                else
                    sum2 += CharToInt(TicketNumber[i]);
            }
            return sum1 == sum2;
        }

        public static void IsSimple(string minTicketNumber, string maxTicketNumber)
        {
            uint min = Convert.ToUInt32(minTicketNumber);
            uint max = Convert.ToUInt32(maxTicketNumber);
            uint count1 = 0;
            uint count2 = 0;
            var ticket = new Ticket();

            for (uint j = min; j <= max; j++)
            {
                ticket.TicketNumber = j.ToString(_format);
                
                //Console.WriteLine(ticket.TicketNumber);
                if (ticket.LuckyTicketSimple())
                {
                    count1++;
                }

                if (ticket.LuckyTicketComplex())
                {
                    count2++;
                }
            }
            Console.WriteLine(count1 + " " + count2);
        }
    }
}
