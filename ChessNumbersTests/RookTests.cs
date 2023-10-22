using ChessNumbers;
using ChessNumbers.ChessPieces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ChessNumbersTests
{

    public class RookTests
    {
        private readonly ITestOutputHelper output;

        public RookTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void TestRook ()
        {
            int index = -1 ; 
            (int x, int y)[] values = { (2, 0), (2, 1), (2, 2), (1, 2), (0, 2), (0, 1), (1, 1) }; 
            var randomCoordinateGeneratorMock =   new Mock<ICoordinatesGenerator>(); 
            var numberFormatter =new  Mock <INumberFormatter>();
            numberFormatter.Setup(x=>x.FormatNumber(It.IsAny<string >() )).Returns((string text ) => text);     
            int currentX =1, currentY =2 ; // 5
            randomCoordinateGeneratorMock.Setup(x => x.GetRandomNumbers(It.IsAny<int>(), It.IsAny<int>())).Returns((int x, int y)=> {

                index += 1;
                output.WriteLine($"X:{values[index].x}, y:{values[index].y}, value : {BoardInfo.Pad[values[index].x, values[index].y]}");
                return  values[index] ; 
            });
          Rook rook = new Rook(randomCoordinateGeneratorMock.Object);
            string results = rook.GetMoveDigits(1, 0);
            Assert.Equal("2369874", results);
            output.WriteLine(results); 

          
        }

        [Fact] 
        public void TestWrongValueInThemiddle ( )
        {
            int index = -1;
            (int x, int y)[] values = { (2, 0), (2, 1), (2, 2),(0,0), (1, 2), (0, 2), (0, 1), (1, 1) };
            var randomCoordinateGeneratorMock = new Mock<ICoordinatesGenerator>();
            var numberFormatter = new Mock<INumberFormatter>();
            numberFormatter.Setup(x => x.FormatNumber(It.IsAny<string>())).Returns((string text) => text);
            int currentX = 1, currentY = 2; // 5
            randomCoordinateGeneratorMock.Setup(x => x.GetRandomNumbers(It.IsAny<int>(), It.IsAny<int>())).Returns((int x, int y) => {

                index += 1;
                output.WriteLine($"X:{values[index].x}, y:{values[index].y}, value : {BoardInfo.Pad[values[index].x, values[index].y]}");
                return values[index];
            });
            Rook rook = new Rook(randomCoordinateGeneratorMock.Object);
            string results = rook.GetMoveDigits(1, 0);
            Assert.Equal("2369874", results);
            output.WriteLine(results);
        }
    }
}
