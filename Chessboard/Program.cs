using ArgumentsProcessor;
using System;

namespace Chessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 0;
            int height = 0;

            if ((args.Length == 2) &&
                Argument.TryParseInt(args[0], 1, Console.LargestWindowWidth, out width) &&
                Argument.TryParseInt(args[1], 1, Console.LargestWindowHeight, out height))
            {
                Chessboard chessboard = new Chessboard(width, height);
                chessboard.PrintChessboard();
            }
            else
            {
                Console.WriteLine("Usage: Chessboard.exe [width] [height]");
            }
        }
    }
}
