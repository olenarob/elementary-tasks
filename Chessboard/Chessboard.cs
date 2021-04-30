using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessboard
{
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
