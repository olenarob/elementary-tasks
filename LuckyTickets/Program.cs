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
            
            int minTicketNumber = Convert.ToInt32(args[0]);
            int maxTicketNumber = Convert.ToInt32(args[1]);
            
            var ticket = new Ticket(6);
            for (int i = minTicketNumber; i <= maxTicketNumber; i++)
            {
                ticket.SetNumber(i);
                
                if (Ticket.IsLuckySimple(ticket))
                    countSimple++;
                
                if (Ticket.IsLuckyComplex(ticket))
                    countComplex++;
            }

            Console.WriteLine($"Number of lucky tickets with a  simple method of counting: {countSimple}");
            Console.WriteLine($"Number of lucky tickets with a complex method of counting: {countComplex}");
            
            switch (countSimple.CompareTo(countComplex))
            {
                case -1:
                    Console.WriteLine("The complex method won!");
                    break;
                case  0:
                    Console.WriteLine("Both methods give the same number of lucky tickets!");
                    break;
                case  1:
                    Console.WriteLine("The simple method won!");
                    break;
            }
                
            var end = GC.GetTotalAllocatedBytes(true);
            Console.WriteLine("Allocated bytes: " + (end - start).ToString());
        }
   }
}
