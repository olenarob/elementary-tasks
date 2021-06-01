using System;
using System.Collections.Generic;

namespace ChessboardApp
{
    class Chessboard : IChessboard
    {
        private IMaxSideProvider maxSideProvider;
        private ushort height;
        private ushort width;
        
        public ushort Width
        {
            get { return width; }
            private set
            {
                if ((value < 0) || (value > maxSideProvider.MaxWidth))
                    throw new OverflowException
                        ($"The width of the chessboard is out of range.");
                else
                    this.width = value;
            }
        }
        
        public ushort Height
        {
            get { return height; }
            private set
            {
                if ((value < 0) || (value > maxSideProvider.MaxHeight))
                    throw new OverflowException
                        ($"The height of the chessboard is out of range.");
                else
                    this.height = value;
            }
        }

        public Chessboard(IMaxSideProvider maxSideProvider) : this (0, 0, maxSideProvider)
        {
        }

        public Chessboard(ushort width, ushort height, IMaxSideProvider maxSideProvider)
        {
            this.maxSideProvider = maxSideProvider;
            SetSides(width, height);
        }

        public void SetSides(ushort width, ushort height)
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
            {
                throw new AggregateException(exceptions);
            }
        }

        public IEnumerable<Cell> GetChessboard()
        {
            for (short i = 0; i < Height; i++)
            {
                for (short j = 0; j < Width; j++)
                {
                    yield return new Cell( i, j, (i + j) % 2 == 0);
                }
            }
        }
    }
}
