namespace ChessboardApp
{
    public struct Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsWhite { get; set; }

        public Cell(int row, int col, bool isWhite)
        {
            Row = row;
            Col = col;
            IsWhite = isWhite;
        }
    }
}
