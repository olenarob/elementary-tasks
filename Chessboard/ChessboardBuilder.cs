using System;
using System.Collections.Generic;

namespace Chessboard
{
    class ChessboardBuilder
    {
        public const ushort minSide = 1;
        
        private ushort height;
        private ushort width;
        
        public ushort Width
        {
            get { return width; }
            set
            {
                if ((value < minSide) || (value > Console.WindowWidth))
                    throw new OverflowException
                        ($"The width of the chessboard is out of range!");
                else
                    this.width = value;
            }
        }
        
        public ushort Height
        {
            get { return height; }
            set
            {
                if ((value < minSide) || (value > Console.WindowHeight))
                    throw new OverflowException
                        ($"The height of the chessboard is out of range!");
                else
                    this.height = value;
            }
        }
        
        public ChessboardBuilder(ushort width, ushort height)
        {
            var exceptions = new List<Exception>(2);
            try
            {
                Width = width;
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }

            try
            {
                Height = height;
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
            
            if (exceptions.Count > 0)
                throw new AggregateException("", exceptions);
        }

        public IEnumerable<char> GetChessboard()
        {
            for (short i = 0; i < Height; i++)
            {
                for (short j = 0; j < Width; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        yield return '*';
                    }
                    else
                    {
                        yield return ' ';
                    }
                }

                foreach (var ch in Environment.NewLine)
                {
                    yield return ch;
                }
            }
        }

        public void DisplayChessboard()
        {
            foreach (var item in GetChessboard())
            {
                Console.Write(item);
            }
        }
    }
}
