using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessNumbers
{
    public static class BoardInfo  
    {

        public  static int[,] Pad = new[,] { { 1, 4, 7,-1 }, { 2, 5, 8,0 }, {3, 6, 9,-1  }  };
        public const int Horizontal = 3;
        public const int Vertical = 4;
        public static (int x, int y)[] SpotsToAvoid = new[] { (0, 3),  (2, 3) };
        public static (int x, int y)[] NoStaringSpots = new[] { (1, 3), (0, 0) }; 
        public const int NumberOfMoves = 7;
    }
}
