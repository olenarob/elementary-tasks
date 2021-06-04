namespace LuckyTickets
{
    public delegate bool IsLuckyTicket(Ticket t);
    
    class Program
    {
        static void Main(string[] args)
        {
            var view = new View();

            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-help":
                        view.DisplayHelp();
                        break;
                    case "-task":
                        view.DisplayTask();
                        break;
                    default:
                        break;
                }
            }
            var model = new Ticket(6);
            var controller = new Controller(model, view);
            controller.Run(args);
        }
   }
}
