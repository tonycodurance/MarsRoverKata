using MarsRoverKata;
using NUnit.Framework;

namespace MarsRoverKataTests
{   
    [TestFixture]
    public class RoverShould
    {
        private const int StartingX = 1;
        private const int StartingY = 2;
        private Rover _rover;

        [TestCase('N', "R" , "0 0 E")]
        [TestCase('S', "R" , "0 0 W")]
        [TestCase('E', "R" , "0 0 S")]
        [TestCase('W', "R" , "0 0 N")]
        [TestCase('N', "RRR" , "0 0 W")]
        public void RotateRightCorrectly(Orientation startingOrientation, string command, string expectedOutput)
        {
            var positionCalculator = new PositionCalculator();
            _rover = new Rover(new Position(0, 0), startingOrientation, positionCalculator);
            
            Assert.AreEqual(_rover.ExecuteCommand(command), expectedOutput);
        }
        
        [TestCase('N', "L" , "0 0 W")]
        [TestCase('S', "L" , "0 0 E")]
        [TestCase('E', "L" , "0 0 N")]
        [TestCase('W', "L" , "0 0 S")]
        [TestCase('N', "LLL" , "0 0 E")]
        public void RotateLeftCorrectly(Orientation startingOrientation, string command, string expectedOutput)
        {
            var positionCalculator = new PositionCalculator();
            _rover = new Rover(new Position(0, 0), startingOrientation, positionCalculator);
            
            Assert.AreEqual(_rover.ExecuteCommand(command), expectedOutput);
        }
        
        [TestCase('N', 1, 3, 1, 5)]
        [TestCase('N', 1, 5, 3, 5)]
        [TestCase('N', 1, 5, 8, 5)]
        [TestCase('N', 1, 5, 13, 5)]
        [TestCase('N', 1, 3, 1, 3)]
        [TestCase('N', 1, 7, 5, 8)]
        [TestCase('N', 1, 7, 13, 8)]
        public void MoveNorthCorrectly(Orientation startingOrientation, int landingX, int landingY, int numberOfMoves, int gridHeight)
        {
            var positionCalculator = new PositionCalculator();
            _rover = new Rover(new Position(StartingX, StartingY), startingOrientation, positionCalculator);

            var landingPosition = new Position(StartingX, StartingY);
            landingPosition = CalculateLandingPosition(startingOrientation, numberOfMoves, gridHeight, landingPosition);

            Assert.AreEqual(landingX, landingPosition.X);
            Assert.AreEqual(landingY, landingPosition.Y);
        }

//        [TestCase('E', 2, 2, 1)]
//        [TestCase('E', 4, 2, 3)]
//        public void MoveNEastCorrectly(Orientation startingOrientation, int landingX, int landingY, int gridWidth)
//        {
//            var positionCalculator = new PositionCalculator();
//            _rover = new Rover(new Position(StartingX, StartingY), startingOrientation, positionCalculator);
//            
//            var result = new Position(StartingX, StartingY);
//            result = CalculateLandingPosition(startingOrientation, gridWidth, result);
//            
//            Assert.AreEqual(landingX, result.X);
//            Assert.AreEqual(landingY, result.Y);
//        }

        private Position CalculateLandingPosition(Orientation startingOrientation, int numberOfMoves, int gridDimension, Position landingPosition)
        {
            for (var i = 0; i < numberOfMoves; i++)
            {
                landingPosition = _rover.Move(new Position(landingPosition.X, landingPosition.Y), startingOrientation, gridDimension);
            }

            return landingPosition;
        }

//        [TestCase(1, 2, 'N', 1, 2, 5)]


//        [TestCase(1, 2, 'N', 1, 2, 10)]


//        [TestCase(1, 2, 'N', 1, 1, 4)]

//        [TestCase(1, 2, 'N', 1, 3, 6)]
//        public void MoveEastAndWrapCorrectlyWhenReachingTheBoundaryOfTheGrid(int startingX, int startingY, Orientation startingOrientation, int landingX, int landingY, int gridHeight)
//        {    
//            var positionCalculator = new PositionCalculator();
//            _rover = new Rover(new Position(1, 2), startingOrientation, positionCalculator);
//
//            var result = new Position(startingX, startingY);
//            for (var i = 0; i < gridHeight; i++)
//            {
//                result = _rover.Move(new Position(result.X, result.Y), startingOrientation);
//            }
//
//            Assert.AreEqual(landingX, result.X);
//            Assert.AreEqual(landingY, result.Y);
//        }
    }
}