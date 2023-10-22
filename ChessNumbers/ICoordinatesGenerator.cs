namespace ChessNumbers
{
    public interface ICoordinatesGenerator
    {
        (int x, int y) GetRandomNumbers(int currentX, int currentY);
        void Reset();
    }
}