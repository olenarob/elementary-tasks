using System.Collections.Generic;

namespace ChessboardApp
{
    public interface IChessboardView : IMaxSideProvider
    {
        void DisplayChessboard(IEnumerable<Cell> chessboardCells);
        void DisplayChessboardHelp();
        void DisplayChessboardTask();
        void DisplayMessage(string text);
    }
}