using System.Collections.Generic;

namespace SortingTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new View();
            var model = new List<Triangle>();
            var controller = new Controller(model, view);
            controller.Run();
        }
    }
}
