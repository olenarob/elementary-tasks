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
                        view.DisplayMessage(args[0]);
                        view.DisplayMessage(model.FileToString(args[0]));
                        view.DisplayMessage(model.SearchInFile(args[0], args[1]));
                        break;
                    case 3:
                        view.DisplayMessage(model.ReplaceInFile(args[0], args[1], args[2]));
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