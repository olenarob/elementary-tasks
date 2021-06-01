using System;

namespace ChessboardApp
{
    public class ChessboardController
    {
        private IChessboard chessboardModel;
        private IChessboardView chessboardView;

        public ChessboardController(IChessboard chessboard, IChessboardView chessboardView)
        {
            this.chessboardModel = chessboard;
            this.chessboardView = chessboardView;
        }

        public void DisplayChessboardInfo(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    throw new IndexOutOfRangeException("Two arguments are expected.");
                }
                chessboardModel.SetSides(width: ushort.Parse(args[0]),
                                        height: ushort.Parse(args[1]));
                chessboardView.DisplayChessboard(this.chessboardModel.GetChessboard());
            }
            catch (AggregateException ex)
            {
                foreach (var exception in ex.InnerExceptions)
                {
                    chessboardView.DisplayMessage(exception.Message);
                }
                chessboardView.DisplayChessboardHelp();
            }
            catch
            {
                chessboardView.DisplayMessage("Invalid argument(s).");
                chessboardView.DisplayChessboardHelp();
            }
        }
    }
}
