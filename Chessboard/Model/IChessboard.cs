using System.Collections.Generic;

namespace ChessboardApp
{
    public interface IChessboard
    {
        ushort Width { get; }
        ushort Height { get; }
        void SetSides(ushort width, ushort height);
        IEnumerable<Cell> GetChessboard();
    }
}
