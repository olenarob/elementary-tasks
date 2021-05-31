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
            chessboardView.DisplayChessboard(this.chessboardModel.GetChessboard());
        }

        public void DisplayChessboardHelp()
        {
            chessboardView.DisplayChessboardHelp(this.chessboardModel.GetChessboardHelp());
        }

        public void DisplayChessboardTask()
        {
            chessboardView.DisplayChessboardTask(this.chessboardModel.GetChessboardTask());
        }
    }
}
