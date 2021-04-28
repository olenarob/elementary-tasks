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

        class Chessboard
        {
            private int _height;
            private int _width;
            
            public Chessboard(int width, int height)
            {
                _width = width;
                _height = height;
            }

            public void PrintChessboard()
            {
                for (int i = 0; i < _height; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        if (i % 2 == 0)
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write("*");
                            }
                            else Console.Write(" ");
                        }
                        else if (j % 2 == 0)
                        {
                            Console.Write(" ");
                        }
                        else Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }

        }
            
    }
}
