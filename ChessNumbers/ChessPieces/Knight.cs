using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessNumbers.ChessPieces
{
    public class Knight:ChessPiece
    {
        public Knight(ICoordinatesGenerator randomCordinatesGenerator):base (randomCordinatesGenerator)
        {
                
        }

        protected override bool IsValidMove((int x, int y) newLocation, (int currentX, int currentY) currentLocation)
        {
            if ( 
                ((newLocation.x == currentLocation.currentX  +1) || (newLocation.x == currentLocation.currentX - 1)) && (newLocation.y == currentLocation.currentY +2 || newLocation.y == currentLocation.currentY - 2) ||

                 ((newLocation.y == currentLocation.currentY + 1) || (newLocation.y == currentLocation.currentY - 1)) && (newLocation.x == currentLocation.currentX + 2 || newLocation.x == currentLocation.currentX - 2)

                )
            {
                return true;    
            }
            return false;   
        }
    }
}
