using System;
using System.Collections.Generic;

namespace ChessboardApp
{
    public interface IMaxSizeProvider
    {
        uint MaxWidth { get; }
        uint MaxHeight { get; }
    }

    public interface IChessboardView : IMaxSizeProvider
    {
        void DisplayChessboard(IEnumerable<char> chessboardItems);
        void DisplayChessboardHelp(IEnumerable<string> helpItems);
        void DisplayChessboardTask(IEnumerable<string> taskItems);
    }

    class ChessboardView : IChessboardView
    {
        public uint MaxWidth => (uint)Console.WindowWidth;

        public uint MaxHeight => (uint)Console.WindowHeight;

        public void DisplayChessboard(IEnumerable<char> chessboardItems)
        {
            Console.WriteLine();
            foreach (var item in chessboardItems)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

        public void DisplayChessboardHelp(IEnumerable<string> helpItems)
        {
            foreach (var item in helpItems)
            {
                Console.WriteLine(item);
            }
        }
        public void DisplayChessboardTask(IEnumerable<string> taskItems)
        {
            foreach (var item in taskItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}