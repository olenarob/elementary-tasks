using System;

namespace Chessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.ReadLine();

            foreach (string s in args)
            {
                Console.ReadKey(s);
                Console.WriteLine($"Arg: {s}");
            }
            */
            Chessboard chessboard = new Chessboard(5,6);
            chessboard.OutputChessboard();

            Console.WriteLine("Hello World!");
        }

        class Chessboard
        {
            private int numberOfRows = 0;
            private int numberOfColumns = 0;
            
            public Chessboard(int numberOfRows, int numberOfColumns)
            {
                this.numberOfRows = numberOfRows;
                this.numberOfColumns = numberOfColumns;
            }

            public void OutputChessboard()
            {
                for (int i = 0; i < numberOfRows; i++)
                {
                    if ((i % 2) == 1)
                        Console.Write(" ");
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
