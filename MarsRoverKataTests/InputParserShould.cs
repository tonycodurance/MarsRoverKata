using MarsRoverKata;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class InputParserShould
    {
        [Test]
        public void ExtractThePositionCorrectlyFromTheInputString()
        {
            var inputString = "5 5\n" +
                              "1 2 N\n" +
                              "LMLMLMLMM";

            var commandParser = new InputParser();
            var result = commandParser.ParseInput(inputString);
            
            Assert.AreEqual(result[1], "1 2 N");
        }
        
        [Test]
        public void ExtractCommandCorrectlyFromInput()
        {
            var inputString = "5 5\n" +
                              "1 2 N\n" +
                              "LMLMLMLMM";

            var commandParser = new InputParser();
            var result = commandParser.ParseInput(inputString);
            
            Assert.AreEqual(result[2], "LMLMLMLMM");
        }
        
        [Test]
        public void ExtractThePlateauDimensionsCorrectly()
        {
            var inputString = "5 5\n" +
                              "1 2 N\n" +
                              "LMLMLMLMM";

            var commandParser = new InputParser();
            var result = commandParser.ParseInput(inputString);
            
            Assert.AreEqual(result[0], "5 5");
        }

        
    }
}