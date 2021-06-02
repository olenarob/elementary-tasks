namespace SortingTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new View();
            var model = new Triangle();
            var controller = new Controller(model, view);
            controller.Run();
        }
    }
}
