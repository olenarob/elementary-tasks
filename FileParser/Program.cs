namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new View();
            var model = new FileStreamParser();
            var controller = new Controller(model, view);
            controller.DisplayInfo(args);
        }
    }
}
