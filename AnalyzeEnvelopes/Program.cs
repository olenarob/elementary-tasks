namespace AnalysisOfEnvelopes
{
    class Program
    {
        static void Main()
        {
            var view = new View();
            view.DisplayTask();
            
            var model = new EnvelopeAnalyser();
            var controller = new Controller(model, view);
            controller.Run();
        }
    }
}
