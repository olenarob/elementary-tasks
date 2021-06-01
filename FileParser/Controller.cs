using System;

namespace FileParser
{
    public class Controller
    {
        private IFileParser model;
        private IView view;

        public Controller(IFileParser model, IView view)
        {
            this.model = model;
            this.view = view;
        }

        public void DisplayInfo(string[] args)
        {
            try
            {
                switch (args.Length)
                {
                    case 2:
                        model.SearchInFile(args[0], args[1]);
                        break;
                    case 3:
                        model.ReplaceInFile(args[0], args[1], args[2]);
                        view.DisplayMessage($"FileParser has completed the processing of {args[0]}.");
                        break;
                    default:
                        view.DisplayHelp();
                        break;
                }
            }
            catch (Exception ex)
            {
                view.DisplayMessage(ex.Message);
                view.DisplayHelp();
            }
        }
    }
}