﻿using System;

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
    public class Ticket
    {
        public string ticketNumber;
        private string format;
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

        static int CharToInt(char c)
        {
            return c - '0';
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
