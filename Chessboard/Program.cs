using System;

namespace ChessboardApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var chessboardView = new ChessboardView();
            
            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-help":
                        chessboardView.DisplayChessboardHelp();
                        break;
                    case "-task":
                        chessboardView.DisplayChessboardTask();
                        break;
                    default:
                        break;
                }
            }

            IChessboard chessboardModel = new Chessboard(chessboardView);
            
            var chessboardController = new ChessboardController(chessboardModel, chessboardView);
            chessboardController.DisplayChessboardInfo(args);
        }
    }
}
