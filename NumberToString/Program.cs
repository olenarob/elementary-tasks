using System;
using System.Numerics;

namespace NumberToString
{
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
                    default:
                        view.DisplayTask();
                        break;
                }
            }
            var model = new NumberToString();
            var controller = new Controller(model, view);
            controller.Run(args);
        }
    }
}
