using System;

namespace Chessboard
{
    internal class View
    {
        public static void Help()
        {
            Console.WriteLine();
            Console.WriteLine("============== Help ===============");
            Console.WriteLine("Usage: Chessboard.exe [width] [height]");
            Console.WriteLine($"The width of the chessboard should range from {ChessboardBuilder.minSide} to {Console.WindowWidth}.");
            Console.WriteLine($"The height of the chessboard should range from {ChessboardBuilder.minSide} to {Console.WindowHeight}.");
        }
        public static void Task()
        {
            Console.WriteLine();
            Console.WriteLine("============== Task 1 Chessboard ===============");
            Console.WriteLine("Output a chessboard with a set height and width, on the principle of:");
            var chessboard = new ChessboardBuilder(12, 4);
            chessboard.GetChessboard();
            chessboard.DisplayChessboard();
            Console.WriteLine("The program runs through a main class call with parameters.");
        }
    }
}