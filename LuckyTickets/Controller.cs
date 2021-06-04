using System;

namespace LuckyTickets
{
    class Controller
    {
        private Ticket model;
        private View view;

        public Controller(Ticket model, View view)
        {
            this.model = model;
            this.view = view;
        }

        public void Run(string[] args)
        {
            try
            {
                int minTicketNumber = int.Parse(args[0]);
                int maxTicketNumber = int.Parse(args[1]);
                
                if ((minTicketNumber < 0 || minTicketNumber > 999999) ||
                        (maxTicketNumber < 0 || maxTicketNumber > 999999))
                {
                    throw new Exception("The lower or/and upper range not a sequence of 6 digit!");
                }
                
                if (minTicketNumber > maxTicketNumber)
                {
                    throw new Exception("The lower range can not be less the upper range!");
                }

                ProccessingRange(minTicketNumber, maxTicketNumber);
            }
            catch (IndexOutOfRangeException)
            {
                view.DisplayHelp();
            }
            catch (FormatException)
            {
                view.DisplayMessage("The lower or/and upper range are not a sequence of 6 digit!");
            }
            catch (Exception ex)
            {
                view.DisplayMessage(ex.Message);
            }
        }

        private void ProccessingRange(int minTicketNumber, int maxTicketNumber)
        {
            int countSimple = 0;
            int countComplex = 0;

            for (int i = minTicketNumber; i <= maxTicketNumber; i++)
            {
                model.SetNumber(i);

                if (Ticket.IsLuckySimple(model))
                    countSimple++;

                if (Ticket.IsLuckyComplex(model))
                    countComplex++;
            }

            DisplayResult(countSimple, countComplex);
        }

        private void DisplayResult(int countSimple, int countComplex)
        {
            view.DisplayMessage($"Number of lucky tickets with a  simple method of counting: {countSimple}");
            view.DisplayMessage($"Number of lucky tickets with a complex method of counting: {countComplex}");

            switch (countSimple.CompareTo(countComplex))
            {
                case -1:
                    view.DisplayMessage("The complex method won!");
                    break;
                case 0:
                    view.DisplayMessage("Both methods give the same number of lucky tickets!");
                    break;
                case 1:
                    view.DisplayMessage("The simple method won!");
                    break;
            }
        }
    }
}
