using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessNumbers.ChessPieces
{
    public class Rook : ChessPiece
    {
        
        public Rook(ICoordinatesGenerator randomCordinatesGenerator ):base(randomCordinatesGenerator)
        {
           
        }

        protected override bool IsValidMove((int x, int y) newLocation, (int currentX, int currentY) currentLocation)
        {

            return newLocation.x != currentLocation.currentX && newLocation.y == currentLocation.currentY || newLocation.x == currentLocation.currentX && newLocation.y != currentLocation.currentY;
        }
    }
}
