using System;

namespace Chessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] maxSizeOfChessboard = new int[2];
            maxSizeOfChessboard[0] = Console.LargestWindowWidth;
            maxSizeOfChessboard[1] = Console.LargestWindowHeight;

            int[] sizeOfChessboard = new int[2];

            if (args.Length == 2)
            {
                try
                {
                    for (int i = 0; i < 2; i++)
                    {
                        sizeOfChessboard[i] = int.Parse(args[i]);

                        if (sizeOfChessboard[i] > maxSizeOfChessboard[i])
                            throw new ArgumentOutOfRangeException();
                    }

                    Chessboard chessboard = new Chessboard(sizeOfChessboard[0], sizeOfChessboard[1]);
                    chessboard.PrintChessboard();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                    Console.WriteLine("Usage: Chessboard.exe 8 8");
                }

            }
            //Console.ReadKey();

        }

        class Chessboard
        {
            private int numberOfRows;
            private int numberOfColumns;
            
            public Chessboard(int numberOfRows, int numberOfColumns)
            {
                this.numberOfRows = numberOfRows;
                this.numberOfColumns = numberOfColumns;
            }

            public void PrintChessboard()
            {
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
