using System;

namespace Chessboard
{
    class Chessboard
    {
        private ushort _height;
        private ushort _width;

        public Chessboard(ushort width, ushort height)
        {
            this._width = width;
           // this._height = height;
        }

        public ushort Height
        {
            get { return _height; }
            set
            {
                if ((value < 1) || (value > Console.LargestWindowHeight))
                    throw new OverflowException($"Width should be in range from 1 to {Console.LargestWindowHeight}");
                else
                    this._height = value;
            }
        }

        public void DisplayChessboard()
        {
            Console.Clear();
            
            for (int i = 0; i < Height; i++)
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
