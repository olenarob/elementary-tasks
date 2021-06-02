namespace AnalysisOfEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new View();
            var model = new EnvelopeAnalyser();
            var controller = new Controller(model, view);
            controller.Run();
        }
    }
}
