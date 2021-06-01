using System;
using System.IO;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new View();
            var model = new FileParser();
            var controller = new Controller(model, view);
            controller.DisplayInfo(args);
        }
    }
}
