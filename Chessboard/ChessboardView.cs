using System;
using System.Collections.Generic;

namespace ChessboardApp
{
    public class ChessboardView : IChessboardView, IMaxSideProvider
    {
        public uint MaxWidth
        {
            get { return (uint)Console.WindowWidth; } 
        }

        public uint MaxHeight
        {
            get { return (uint)Console.WindowHeight; }
        }
        
        public void DisplayChessboard(IEnumerable<Cell> chessboardCells)
        {
            Console.WriteLine($"==================== Chessboard ====================");
            int flag = 0;
            foreach (var cell in chessboardCells)
            {
                if (flag != cell.Row)
                {
                    Console.WriteLine();
                    flag = cell.Row;
                }
                
                switch (cell.IsWhite)
                {
                    case false:
                        Console.Write('*');
                        break;
                    case true:
                        Console.Write(' ');
                        break;
                }
            }
            Console.WriteLine();
        }

        public void DisplayChessboardHelp()
        {
            Console.WriteLine();
            Console.WriteLine("======================== Help =======================");
            Console.WriteLine("Usage: Chessboard.exe <width> <height>");
            Console.WriteLine($"Width is an integer from 1 to {MaxWidth}.");
            Console.WriteLine($"Height is an integer from 1 to {MaxHeight}.");
            Console.WriteLine();
        }

        public void DisplayChessboardTask()
        {
            Console.WriteLine();
            Console.WriteLine($"================= Task 1 Chessboard ================");
            Console.WriteLine("Output a chessboard with a set height and width, on the principle of:");
            Console.WriteLine("* * * * * * ");
            Console.WriteLine(" * * * * * *");
            Console.WriteLine("* * * * * * ");
            Console.WriteLine(" * * * * * *");
            Console.WriteLine("The program runs through a main class call with parameters.");
            Console.WriteLine();
        }

        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }
    }
}