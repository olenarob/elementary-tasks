using ArgumentsProcessor;
using System;

namespace Chessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            const ushort minChessboardSize = 0;
            
            if ((args.Length == 2) &&
                Argument.TryParse<ushort>(args[0], minChessboardSize, (ushort)Console.LargestWindowWidth, out ushort width) &&
                Argument.TryParse<ushort>(args[1], minChessboardSize, ushort.MaxValue, out ushort height))
            {
                try
                {
                    var chessboard = new Chessboard(width, height);
                    chessboard.Height = height;
                    chessboard.DisplayChessboard();
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Usage: Chessboard.exe [width] [height]");
            }
        }
    }
}
