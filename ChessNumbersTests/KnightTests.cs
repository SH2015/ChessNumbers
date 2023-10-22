using ChessNumbers.ChessPieces;
using ChessNumbers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ChessNumbersTests
{
    public class KnightTests
    {
        private readonly ITestOutputHelper output;

        public KnightTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void TestKnight_Default_Success()
        {
            int index = -1;
            (int x, int y)[] values = {  (2,0), (0, 1), (2, 2), (1, 0), (0, 2), (2, 1), (0,0) };
            var randomCoordinateGeneratorMock = new Mock<ICoordinatesGenerator>();
           
          
            int currentX = 1, currentY = 2; // 5
            randomCoordinateGeneratorMock.Setup(x => x.GetRandomNumbers(It.IsAny<int>(), It.IsAny<int>())).Returns((int x, int y) => {

                index += 1;
                output.WriteLine($"X:{values[index].x}, y:{values[index].y}, value : {BoardInfo.Pad[values[index].x, values[index].y]}");
                return values[index];
            });
            Knight knight = new Knight(randomCoordinateGeneratorMock.Object );
            string results = knight.GetMoveDigits(1, 2);
            Assert.Equal("8349276", results);
            output.WriteLine(results);


        }

        [Fact]
        public void TesKight_WrongValueInThemiddle_Success()
        {
            int index = -1;
            (int x, int y)[] values = { (1, 2), (2,0), (0,1), (2,2), (1, 0), (0, 2), (2, 1), (2, 1) };
            var randomCoordinateGeneratorMock = new Mock<ICoordinatesGenerator>();
            var numberFormatter = new Mock<INumberFormatter>();
            numberFormatter.Setup(x => x.FormatNumber(It.IsAny<string>())).Returns((string text) => text);
            int currentX = 1, currentY = 2; // 5
            randomCoordinateGeneratorMock.Setup(x => x.GetRandomNumbers(It.IsAny<int>(), It.IsAny<int>())).Returns((int x, int y) => {

                index += 1;
                output.WriteLine($"X:{values[index].x}, y:{values[index].y}, value : {BoardInfo.Pad[values[index].x, values[index].y]}");
                return values[index];
            });
            Knight knight = new Knight(randomCoordinateGeneratorMock.Object);
            string results = knight.GetMoveDigits(1, 2);
            Assert.Equal("8349276", results);
            output.WriteLine(results);
        }
    }
}
