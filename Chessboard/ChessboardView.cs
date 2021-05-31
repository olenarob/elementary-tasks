using System;

namespace ChessboardApp
{
    interface IChessboardView
    {
        void DisplayChessboardView(IChessboard chessboard);
    }

    class ChessboardView : IChessboardView
    {
        public void DisplayChessboardView(IChessboard chessboard)
        {
            Console.WriteLine("Chessboard");
            Console.WriteLine("===============================");
            foreach (var item in chessboard.GetChessboard())
            {
                Console.Write(item);
            }
        }

        public static void Help()
        {
            Console.WriteLine();
            Console.WriteLine("================ Help ================");
            Console.WriteLine("Usage: Chessboard.exe <width> <height>");
            Console.WriteLine($"Width should range from {Chessboard.minSide} to {Console.WindowWidth}.");
            Console.WriteLine($"Height should range from {Chessboard.minSide} to {Console.WindowHeight}.");
        }
        public static void Task()
        {
            Console.WriteLine();
            Console.WriteLine($"============== Task 1 {typeof(Chessboard).Name} ===============");
            Console.WriteLine("Output a chessboard with a set height and width, on the principle of:");
            
            IChessboard chessboardModel = new Chessboard(12, 4);
            IChessboardView chessboardView = new ChessboardView();
            var chessboardController = new ChessboardController(chessboardModel, chessboardView);
            chessboardController.DisplayChessboardInfo();

            Console.WriteLine("The program runs through a main class call with parameters.");
        }
    }
}