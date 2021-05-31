using System;

namespace ChessboardApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IChessboardView chessboardView = new ChessboardView();
            var chessboardHelpController = new ChessboardController(new Chessboard(chessboardView), chessboardView);
            try
            {
                foreach (var arg in args)
                {
                    switch (arg)
                    {
                        case "-help":
                            chessboardHelpController.DisplayChessboardHelp();
                            break;
                        case "-task":
                            chessboardHelpController.DisplayChessboardTask();
                            break;
                        default:
                            break;
                    }
                }

                var width = ushort.Parse(args[0]);
                var height = ushort.Parse(args[1]);
                IChessboard chessboardModel = new Chessboard(width, height, chessboardView);
                
                var chessboardController = new ChessboardController(chessboardModel, chessboardView);
                chessboardController.DisplayChessboardInfo();

                Console.ReadLine();
            }
            catch (AggregateException ex)
            {
                foreach (var exception in ex.InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                }
                chessboardHelpController.DisplayChessboardHelp();
            }
            catch (Exception)
            {
                chessboardHelpController.DisplayChessboardHelp();
            }

        }
    }
}
