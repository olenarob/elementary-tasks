using System;

namespace Chessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                foreach (var item in args)
                {
                    switch (item)
                    {
                        case "-help":
                            View.Help();
                            break;
                        case "-task":
                            View.Task();
                            break;
                        default:
                            break;
                    }
                }

                ushort width = ushort.Parse(args[0]);
                ushort height = ushort.Parse(args[1]);

                var chessboard = new ChessboardBuilder(width, height);
                chessboard.GetChessboard();
                chessboard.DisplayChessboard();
            }
            catch (AggregateException ex)
            {
                foreach (var exception in ex.InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                }
                View.Help();
            }
            catch (Exception)
            {
                View.Help();
            }
        }
    }
}
