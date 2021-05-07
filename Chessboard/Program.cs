using ArgumentsProcessor;
using System;

namespace Chessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            int width;
            int height;
            const int minChessboardSize = 1;

            if ((args.Length == 2) &&
                Argument.TryParseInt(args[0], minChessboardSize, Console.LargestWindowWidth, out width) &&
                Argument.TryParseInt(args[1], minChessboardSize, Console.LargestWindowHeight, out height))
            {
                var chessboard = new Chessboard(width, height);
                chessboard.PrintChessboard();
            }
            else
            {
                Console.WriteLine("Usage: Chessboard.exe [width] [height]");
            }
        }
    }
}
