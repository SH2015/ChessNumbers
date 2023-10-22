using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChessNumbers
{
    public class CoordinatesGenerator : ICoordinatesGenerator
    {
        int X, Y;

        public CoordinatesGenerator()
        {


        }
        public (int x, int y) GetRandomNumbers(int currentX, int currentY)
        {
        // instead of for it is better to have Random to get all possible paths , but that will require more code to manage state and remove duplicate 
            for (int x = X; x <= BoardInfo.Horizontal; x++)
            {
                for (int y = Y; y <= BoardInfo.Vertical; y++)
                {
                    if (x == currentX && y == currentY)
                    {
                        continue;
                    }

                    if (!BoardInfo.SpotsToAvoid.Any(pair => pair.x == x && pair.y == y) && (x != currentX && y != currentY))
                    {
                        X = x;
                        Y = y + 1;
                        return (x, y);
                    }

                }

            }
            return (-1, -1);

        }

        public void Reset()
        {
            X = Y = 0;
        }
    }
}
