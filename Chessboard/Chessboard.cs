using System;

namespace Chessboard
{
    class Chessboard
    {
        private ushort _height;
        private ushort _width;

        public Chessboard(ushort width, ushort height)
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
