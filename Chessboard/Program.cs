using ArgumentsProcessor;
using System;

namespace Chessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort width;
            ushort height;
            const ushort minChessboardSize = 1;
            Console.Clear();
            if ((args.Length == 2) &&
                Argument.TryParse<ushort>(args[0], minChessboardSize, (ushort)(Console.LargestWindowWidth), out width) &&
                Argument.TryParse<ushort>(args[1], minChessboardSize, (ushort)Console.LargestWindowHeight, out height))
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
