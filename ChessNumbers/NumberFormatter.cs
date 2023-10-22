using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessNumbers
{
    public class NumberFormatter : INumberFormatter
    {
        public string FormatNumber(string number)
        {
            if (number.Length != 7)
            {
                throw new InvalidDataException("Number should be made of 7 digits");
            }

            return $"{number.Substring(0, 3)}-{number.Substring(3, 4)}";
        }
    }
}
