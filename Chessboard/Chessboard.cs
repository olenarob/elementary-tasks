using System;
using System.Collections.Generic;

namespace ChessboardApp
{
    interface IChessboard
    {
        ushort Width { get; set; }
        ushort Height { get; set; }
        IEnumerable<char> GetChessboard();
        IEnumerable<string> GetChessboardHelp();
        IEnumerable<string> GetChessboardTask();
    }

    class Chessboard : IChessboard
    {
        private const ushort MinSide = 1;
        private IMaxSizeProvider maxSizeProvider;
        private ushort height;
        private ushort width;
        
        public ushort Width
        {
            get { return width; }
            set
            {
                if ((value < MinSide) || (value > maxSizeProvider.MaxWidth))
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
                if ((value < MinSide) || (value > maxSizeProvider.MaxHeight))
                    throw new OverflowException
                        ($"The height of the chessboard is out of range!");
                else
                    this.height = value;
            }
        }

        public Chessboard(IMaxSizeProvider maxSizeProvider) : this (12, 4, maxSizeProvider)
        {
        }
        public Chessboard(ushort width, ushort height, IMaxSizeProvider maxSizeProvider)
        {
            this.maxSizeProvider = maxSizeProvider;

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
                throw new AggregateException("", exceptions); ;
            }
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

                foreach (var character in Environment.NewLine)
                {
                    yield return character;
                }
            }
        }

        public IEnumerable<string> GetChessboardHelp()
        {
            yield return "";
            yield return "================ Help ================";
            yield return "Usage: Chessboard.exe <width> <height>";
            yield return $"Width should range from {MinSide} to {maxSizeProvider.MaxWidth}.";
            yield return $"Height should range from {MinSide} to {maxSizeProvider.MaxHeight}.";
        }

        public IEnumerable<string> GetChessboardTask()
        {
            yield return "";
            yield return $"============== Task 1 {typeof(Chessboard).Name} ===============";
            yield return "Output a chessboard with a set height and width, on the principle of:";
            yield return "* * * * * * ";
            yield return " * * * * * *";
            yield return "* * * * * * ";
            yield return " * * * * * *";
            yield return "The program runs through a main class call with parameters.";
        }
    }
}
