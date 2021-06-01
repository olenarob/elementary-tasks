namespace ChessboardApp
{
    public interface IMaxSideProvider
    {
        uint MaxWidth { get; }
        uint MaxHeight { get; }
    }
}