using System;

namespace Chessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ushort width = ushort.Parse(args[0]);
                ushort height = ushort.Parse(args[1]);

                var chessboard = new Chessboard(width, height);
                chessboard.DisplayChessboard();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Usage: Chessboard [width] [height]");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
