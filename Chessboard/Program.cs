using System;

namespace ChessboardApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                foreach (var arg in args)
                {
                    switch (arg)
                    {
                        case "-help":
                            ChessboardView.Help();
                            break;
                        case "-task":
                            ChessboardView.Task();
                            break;
                        default:
                            break;
                    }
                }

                var width = ushort.Parse(args[0]);
                var height = ushort.Parse(args[1]);

                IChessboard chessboardModel = new Chessboard(width, height);
                IChessboardView chessboardView = new ChessboardView();

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
                ChessboardView.Help();
            }
            catch (Exception)
            {
                ChessboardView.Help();
            }

        }
    }
}
