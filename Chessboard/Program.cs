using ArgumentsProcessor;
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

                // Argument.TryParse<ushort>(args[0], ushort.MinValue, ushort.MaxValue, out ushort width);
                // Argument.TryParse<ushort>(args[1], ushort.MinValue, ushort.MaxValue, out ushort height);

                var chessboard = new Chessboard(width, height);
                chessboard.DisplayChessboard();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Usage: Chessboard.exe [width] [height]");
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
