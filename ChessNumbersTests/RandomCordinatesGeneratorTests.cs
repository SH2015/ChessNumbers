using ChessNumbers;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Xml.Serialization;
using Xunit.Abstractions;

namespace ChessNumbersTests
{
    public class RandomCordinatesGeneratorTests
    {
        public RandomCordinatesGeneratorTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        CoordinatesGenerator randomCordinatesGenerator;
        private readonly ITestOutputHelper output;

        [Fact]
       
        public void TestAllowedNumber()
        {
          
            randomCordinatesGenerator = new CoordinatesGenerator();

            for (int i = 0; i < 1000 ; i++)
            {
                (int x, int y) = randomCordinatesGenerator.GetRandomNumbers(2, 2);
                Assert.DoesNotContain(BoardInfo.SpotsToAvoid, pair => pair.Item1 == x && pair.Item2 == y);
                Assert.NotEqual(2,x); 
                Assert.NotEqual(2,y);     
                output.WriteLine($"X={x}, Y={y}"); 
            }
        }
    }
}