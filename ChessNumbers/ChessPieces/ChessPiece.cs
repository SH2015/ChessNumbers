using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessNumbers.ChessPieces
{
    public abstract class ChessPiece
    {
        private readonly ICoordinatesGenerator cordinatesGenerator;

        public ChessPiece(ICoordinatesGenerator cordinatesGenerator )
        {
            this.cordinatesGenerator = cordinatesGenerator;
        }
        public   string GetMoveDigits(int currentX, int currentY)
        {
            cordinatesGenerator.Reset();
            StringBuilder stringBuilder = new StringBuilder(BoardInfo.Pad[currentX, currentY].ToString());
            do
            {
              
                (int nextX, int nextY) = cordinatesGenerator.GetRandomNumbers(BoardInfo.Horizontal, BoardInfo.Vertical);
                if (nextX == -1)
                    return new string('#', 7);
                if (IsValidMove((nextX, nextY), (currentX, currentY)))
                {

                    stringBuilder.Append(BoardInfo.Pad[nextX, nextY].ToString());
                    currentX = nextX;
                    currentY = nextY;
                    cordinatesGenerator.Reset();
                }
            } while (stringBuilder.Length < BoardInfo.NumberOfMoves);

            return  stringBuilder.ToString() ;
        }
        protected abstract bool IsValidMove((int x, int y) newLocation, (int currentX, int currentY) currentLocation);

    }
}
