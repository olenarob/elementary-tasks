using System;

namespace ChessboardApp
{
    class ChessboardController
    {
        private IChessboard chessboardModel;
        private IChessboardView chessboardView;

        public ChessboardController(IChessboard chessboard, IChessboardView chessboardView)
        {
            this.chessboardModel = chessboard;
            this.chessboardView = chessboardView;
        }

        public void DisplayChessboardInfo()
        {
            chessboardView.DisplayChessboardView(this.chessboardModel);
        }
    }
}
