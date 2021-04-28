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
                Console.WriteLine(args.Length);
                Chessboard chessboard = new Chessboard(width, height);
                chessboard.PrintChessboard();
            }
            else
            {
                Console.WriteLine("Usage: Chessboard.exe [width] [height]");
            }
            
            //Console.ReadKey();

        }

        class Chessboard
        {
            private int numberOfRows;
            private int numberOfColumns;
            
            public Chessboard(int width, int height)
            {
                numberOfColumns = width;
                numberOfRows = height;
            }

            public void PrintChessboard()
            {
                Console.SetBufferSize(numberOfColumns+1,numberOfRows);

                for (int i = 0; i < numberOfRows; i++)
                {
                    if ((i % 2) == 1)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < numberOfColumns; j++)
                    {
                        Console.Write("* ");
                    }
                    Console.WriteLine();
                }
            }

        }
            
    }
}
