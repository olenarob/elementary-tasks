namespace AnalysisOfEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new View();
            var model = new PairOfEnvelopes();
            var controller = new Controller(model, view);
            controller.Run();
        }
    }
}
