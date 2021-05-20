using System;

namespace Chessboard
{
    class Chessboard
    {
        const ushort minChessboardSide = 1;
        
        private ushort height;
        private ushort width;
        
        public ushort Width
        {
            get { return width; }
            set
            {
                if ((value < minChessboardSide) || (value > Console.LargestWindowWidth))
                    throw new OverflowException
                        ($"The width of the chessboard should range from {minChessboardSide} to {Console.LargestWindowWidth}.");
                else
                    this.width = value;
            }
        }
        
        public ushort Height
        {
            get { return height; }
            set
            {
                if ((value < minChessboardSide) || (value > Console.LargestWindowHeight))
                    throw new OverflowException
                        ($"The height of the chessboard should range from {minChessboardSide} to {Console.LargestWindowHeight}.");
                else
                    this.height = value;
            }
        }
        
        public Chessboard(ushort width, ushort height)
        {
            Width = width;
            Height = height;
        }
        public void DisplayChessboard()
        {
            Console.Clear();
            
            for (ushort i = 0; i < Height; i++)
            {
                for (ushort j = 0; j < Width; j++)
                {
                    if ((i + j) % 2 == 0)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
